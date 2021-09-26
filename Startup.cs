using System;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scadenzario.Customizations.Identity;
using Scadenzario.Customizations.ModelBinders;
using Scadenzario.Models.Options;
using Scadenzario.Models.Services.Application;
using Scadenzario.Models.Services.Application.Beneficiari;
using Scadenzario.Models.Services.Application.Scadenze;
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
            services.AddReCaptcha(options =>
            {
                options.SecretKey = Environment.GetEnvironmentVariable("ReCaptcha:SecretKey", EnvironmentVariableTarget.User);
                options.SiteKey = Environment.GetEnvironmentVariable("ReCaptcha:SiteKey", EnvironmentVariableTarget.User);
                options.Version = ReCaptchaVersion.V2;
            });
            services.AddResponseCaching();
            services.AddMvc(Options=>{
                Options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                var homeProfile = new CacheProfile();
                //homeProfile.Duration = Configuration.GetValue<int>("ResponseCache:Home:Duration");
                //homeProfile.Location = Configuration.GetValue<ResponseCacheLocation>("ResponseCache:Home:Location");
                homeProfile.VaryByQueryKeys= new string[]{"Page"};
                Options.CacheProfiles.Add("Home",homeProfile);
                Configuration.Bind("ResponseCache:Home", homeProfile);
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IScadenzeService,EFCoreScadenzaService>();
            services.AddTransient<IBeneficiariService,EFCoreBeneficiarioService>();
            services.AddTransient<IRicevuteService,EFCoreRicevutaService>();
            services.AddTransient<ICachedScadenzaService,MemoryCacheScadenzaService>();
            services.AddTransient<ICachedBeneficiarioService,MemoryCacheBeneficiarioService>();
            services.AddDbContextPool<MyScadenzaDbContext>(optionsBuilder=>{
                 //ConnectionString:Server=NOME COMPUTER\SQLEXPRESS;Database=Scadenzario;Trusted_Connection=True;
                 string ConnectionString =Environment.GetEnvironmentVariable("ConnectionStrings:Default",EnvironmentVariableTarget.User);
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
            services.Configure<MemoryCacheOptions>(Configuration.GetSection("MemoryCache"));
            services.Configure<ScadenzeOptions>(Configuration.GetSection("Scadenze"));
            services.Configure<BeneficiariOptions>(Configuration.GetSection("Beneficiari"));
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Environment.GetEnvironmentVariable("Authentication:LoginFacebook:AppId",EnvironmentVariableTarget.User);
                facebookOptions.AppSecret = Environment.GetEnvironmentVariable("Authentication:LoginFacebook:AppSecret",EnvironmentVariableTarget.User);
            });
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Environment.GetEnvironmentVariable("Authentication:LoginGoogle:ClientID",EnvironmentVariableTarget.User);
                googleOptions.ClientSecret = Environment.GetEnvironmentVariable("Authentication:LoginGoogle:ClientSecret",EnvironmentVariableTarget.User);
            });
            services.AddAuthentication().AddTwitter(twitterOptions =>
            {
                twitterOptions.ConsumerKey = Environment.GetEnvironmentVariable("Authentication:LoginTwitter:consumerkey",EnvironmentVariableTarget.User);
                twitterOptions.ConsumerSecret = Environment.GetEnvironmentVariable("Authentication:LoginTwitter:consumersecret",EnvironmentVariableTarget.User);
            });
            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Environment.GetEnvironmentVariable("Authentication:LoginMicrosoft:id",EnvironmentVariableTarget.User);
                microsoftOptions.ClientSecret = Environment.GetEnvironmentVariable("Authentication:LoginMicrosoft:key",EnvironmentVariableTarget.User);
            });
            services.AddAuthentication().AddYahoo(options =>
            {
                options.ClientId = Environment.GetEnvironmentVariable("Authentication:LoginYahoo:clientid",EnvironmentVariableTarget.User);
                options.ClientSecret = Environment.GetEnvironmentVariable("Authentication:LoginYahoo:clientsecret",EnvironmentVariableTarget.User);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            //Endpoint routing Middleware
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
            app.UseResponseCaching();
            app.UseEndpoints(routeBuilder => {
                routeBuilder.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routeBuilder.MapRazorPages();
            });
            
        }
    }
}
