using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scadenzario.Customizations.Identity;
using Scadenzario.Models.Entities;
using Scadenzario.Models.Options;
using Scadenzario.Models.Services.Application;
using Scadenzario.Models.Services.Infrastructure;

namespace Scadenzario
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IScadenzeService,EFCoreScadenzaService>();
            services.AddTransient<IBeneficiariService,EFCoreBeneficiarioService>();
            services.AddTransient<IRicevuteService,EFCoreRicevutaService>();
            services.AddDbContextPool<MyScadenzaDbContext>(optionsBuilder=>{
                 String ConnectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default"); 
                 optionsBuilder.UseSqlServer(ConnectionString);
            });
            services.AddDefaultIdentity<IdentityUser>(options=>{
                                 options.Password.RequireDigit=true;
                                 options.Password.RequiredLength=8;
                                 options.Password.RequireUppercase=true;
                                 options.Password.RequireLowercase=true;
                                 options.Password.RequiredUniqueChars=3;
                                 //Conferma Account
                                 options.SignIn.RequireConfirmedAccount=true;
                                 //Blocco dell'account
                                 options.Lockout.AllowedForNewUsers=true;
                                 options.Lockout.MaxFailedAccessAttempts=5;
                                 options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<MyScadenzaDbContext>()
            .AddPasswordValidator<CommonPasswordValidator<IdentityUser>>();
            services.AddSingleton<IEmailSender, MailKitEmailSender>();
            //Options
            services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //Endpoint routing Middleware
            //Nel caso volessi impostare una Culture specifica...
            
            /*var appCulture = CultureInfo.GetCultureInfo("it-IT");
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(appCulture),
                SupportedCultures = new[] { appCulture }
            });*/

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //EndpointMiddleware

            /*--Una route viene identificata da un nome, in questo caso default
            e tre frammenti controller,action e id. Grazie a questa Route il
            meccanismo di routing è in grado di soddisfare le richieste. Facciamo un esempio
            Supponiamo che arrivi la seguente richiesta HTTP /Scadenze/Detail/5
            Grazie a questo template il meccanismo di routing sa che deve andare a chiamare
            un controller chiamato Scadenze, la cui action è Detail e a cui passa
            l'id 5.*/
            
            app.UseEndpoints(routeBuilder => {
                routeBuilder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routeBuilder.MapRazorPages();
            });
            
        }
    }
}
