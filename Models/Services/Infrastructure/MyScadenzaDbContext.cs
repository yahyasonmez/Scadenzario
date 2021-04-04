﻿using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Scadenzario.Models.Entities;

#nullable disable

namespace Scadenzario.Models.Services.Infrastructure
{
    public partial class MyScadenzaDbContext:IdentityDbContext
    {
       
        public MyScadenzaDbContext(DbContextOptions<MyScadenzaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficiario> Beneficiari { get; set; }
        public virtual DbSet<Ricevuta> Ricevute { get; set; }
        public virtual DbSet<Scadenza> Scadenze { get; set; }

        public IConfiguration Configuration { get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
        {
            if (!optionsBuilder.IsConfigured)
            {
                String ConnectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default"); 
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.Entity<Beneficiario>(entity =>
            {
                entity.HasKey(e => e.IDBeneficiario);
                entity.Property(z=>z.IDBeneficiario).ValueGeneratedOnAdd();
                
                entity.ToTable("Beneficiari");//Superfluo se la tabella ha lo stesso nome della proprietà che espone il DbSet

                /*--Finchè la proprietà ha lo stesso nome della colonna del database è superfluo fare il mapping*/
                entity.Property(e => e.Sbeneficiario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Beneficiario")
                    .HasColumnType("nvarchar");  


                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasColumnName("Descrizione")
                    .HasColumnType("nvarchar(MAX)");  

                entity.Property(e => e.SitoWeb)
                    .IsRequired(false)
                    .HasColumnName("SitoWeb")
                    .HasMaxLength(150)
                    .HasColumnType("nvarchar"); 

                entity.Property(e => e.Email)
                    .IsRequired(false)
                    .HasColumnName("Email")
                    .HasMaxLength(150)
                    .HasColumnType("nvarchar"); 

                entity.Property(e => e.Telefono)
                    .IsRequired(false)
                    .HasColumnName("Telefono")
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");                  
                
                //MAPPING DELLE RELAZIONI

                /*--mappare le relazioni. Le relazioni ci consentono di usare le proprietà di
                navigazione Scadenze è una proprietà di navigazione e ci permette di
                passare da un'entità all'altra senza join che tipicamente si fanno nel mondo
                relazionale. HasMany ci permette di dire che dal punto di vista dell'entità
                Beneficiario un Beneficiario ha molte Scadenze, poi con WithOne ci mettiamo dal
                punto di vista della Scadenza che ha una solo beneficiario, infine si
                mappa la chiave esterna.--*/

                entity.HasMany(beneficiario => beneficiario.Scadenze)
                    .WithOne(scadenza => scadenza.beneficiario)
                    .HasForeignKey(scadenza => scadenza.IDScadenza)
                    .HasConstraintName("FK_Scadenze_Beneficiario")
                    .OnDelete(DeleteBehavior.Cascade);
                    

                //MAPPING RELAZIONI    
                entity.HasMany(ricevuta=>ricevuta.Scadenze) 
                      .WithOne(scadenza=>scadenza.beneficiario) 
                      .HasForeignKey(scadenza=>scadenza.IDBeneficiario);                 

            });

            modelBuilder.Entity<Ricevuta>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(z=>z.Id).ValueGeneratedOnAdd();

                entity.ToTable("Ricevute");//Superfluo se la tabella ha lo stesso nome della proprietà che espone il DbSet.
                
                entity.Property(e => e.FileName)
                    .IsRequired()

                    .HasMaxLength(150)
                    .HasColumnName("FileName")
                    .HasColumnType("nvarchar");

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(50)

                    .HasMaxLength(450)
                    .HasColumnName("FileName")
                    .HasColumnType("nvarchar");

                 entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("Path")
                    .HasColumnType("nvarchar");    

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(500)

                    .HasColumnName("FileType")
                    .HasColumnType("nvarchar");  

                 entity.Property(e => e.FileContent)
                    .IsRequired()
                    .HasColumnName("FileContent")
                    .HasColumnType("image");  

                entity.Property(e => e.Beneficiario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Beneficiario")
                    .HasColumnType("nvarchar");          

            });
            modelBuilder.Entity<Scadenza>(entity =>
            {
                entity.HasKey(z=>z.IDScadenza);
                entity.Property(z=>z.IDScadenza).ValueGeneratedOnAdd();
                
                entity.ToTable("Scadenze");//Superfluo se la tabella ha lo stesso nome della proprietà che espone il DbSet.
                
                entity.Property(z=>z.Importo)
                    .HasPrecision(10,2)
                    .HasColumnType("decimal")
                    .IsRequired();

                entity.Property(e => e.Beneficiario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Beneficiario")
                    .HasColumnType("nvarchar");

                entity.Property(e => e.DataScadenza)
                    .IsRequired()
                    .HasColumnName("DataScadenza")
                    .HasColumnType("datetime");
                
                
                entity.Property(e => e.DataPagamento)
                    .HasColumnName("DataPagamento")
                    .HasColumnType("datetime")
                    .IsRequired(false);
                
                entity.Property(e => e.Sollecito)
                    .HasColumnName("Sollecito")
                    .HasColumnType("bit")
                    .IsRequired(true) 
                    .HasDefaultValue(0);
                    
                 entity.Property(e => e.GiorniRitardo)
                    .HasColumnName("GiorniRitardo")
                    .HasColumnType("smallint")
                    .IsRequired(false);

               
               //MAPPING DELLE RELAZIONI

               /*--mappare le relazioni. Le relazioni ci consentono di usare le proprietà di
               navigazione Ricevute è una proprietà di navigazione e ci permette di
               passare da un'entità all'altra senza join che tipicamente si fanno nel mondo
               relazionale. HasMany ci permette di dire che dal punto di vista dell'entità
               Scadenza una Scadenza ha molte ricevute, poi con WithOne ci mettiamo dal
               punto di vista della ricevuta che ha una sola Scadenza, infine si
               mappa la chiave esterna.--*/

               entity.HasMany(scadenza => scadenza.Ricevute)
                    .WithOne(ricevuta => ricevuta.Scadenza)
                    .HasForeignKey(ricevuta => ricevuta.IDScadenza)
                    .HasConstraintName("FK_Scadenze_Ricevute")
                    .OnDelete(DeleteBehavior.Cascade);  
            });

            modelBuilder.Entity<ApplicationUser>(entity => {
            //Mapping delle relazioni        
                    entity.HasMany(user=>user.Scadenze) 
                          .WithOne(Scadenza=>Scadenza.ApplicationUser)
                          .HasForeignKey(Scadenza=>Scadenza.IDUser)
                          .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
