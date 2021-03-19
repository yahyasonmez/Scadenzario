using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scadenzario.Models.Entities;

#nullable disable

namespace Scadenzario.Models.Services.Infrastructure
{
    public partial class MyScadenzaDbContext : DbContext
    {
        public MyScadenzaDbContext(DbContextOptions<MyScadenzaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficiario> Beneficiari { get; set; }
        public virtual DbSet<Ricevuta> Ricevute { get; set; }
        public virtual DbSet<Scadenza> Scadenze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-SMBSSRS2\\SQLEXPRESS;Database=Scadenzario;Trusted_Connection=True;User ID=LAPTOP-SMBSSRS2\\marco;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Beneficiario>(entity =>
            {
                entity.HasKey(e => e.IDBeneficiario);

                entity.ToTable("Beneficiari");//Superfluo se la tabella ha lo stesso nome della proprietà che espone il DbSet

                /*--Finchè la proprietà ha lo stesso nome della colonna del database è superfluo fare il mapping*/
                entity.Property(e => e.Sbeneficiario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Beneficiario");
                
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
                    .HasConstraintName("FK_Scadenze_Beneficiario");
            });

            modelBuilder.Entity<Ricevuta>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Ricevute");//Superfluo se la tabella ha lo stesso nome della proprietà che espone il DbSet.

            });
            modelBuilder.Entity<Scadenza>(entity =>
            {
                entity.HasKey(e => e.IDScadenza);

                entity.ToTable("Scadenze");//Superfluo se la tabella ha lo stesso nome della proprietà che espone il DbSet.
               
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
                    .HasConstraintName("FK_Scadenze_Ricevute");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
