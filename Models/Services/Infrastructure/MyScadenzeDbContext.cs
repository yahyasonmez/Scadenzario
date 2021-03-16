using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scadenzario.Models.Entities;

#nullable disable

namespace Scadenzario.Models.Services.Infrastructure
{
    public partial class MyScadenzeDbContext : DbContext
    {
        public MyScadenzeDbContext()
        {
        }

        public MyScadenzeDbContext(DbContextOptions<MyScadenzeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficiari> Beneficiaris { get; set; }
        public virtual DbSet<Ricevute> Ricevutes { get; set; }
        public virtual DbSet<Scadenze> Scadenzes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-SMBSSRS2\\SQLEXPRESS;Database=Scadenzario;Trusted_Connection=True;User ID=LAPTOP-SMBSSRS2\\\\\\\\marco;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Beneficiari>(entity =>
            {
                entity.HasKey(e => e.Idbeneficiario);

                entity.ToTable("Beneficiari");

                entity.Property(e => e.Idbeneficiario).HasColumnName("IDBeneficiario");

                entity.Property(e => e.Beneficiario)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Descrizione).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.SitoWeb).HasMaxLength(80);

                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<Ricevute>(entity =>
            {
                entity.ToTable("Ricevute");

                entity.Property(e => e.Beneficiario)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FileContent)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Idscadenza).HasColumnName("IDScadenza");

                entity.HasOne(d => d.Idscadenze)
                    .WithMany(p => p.Ricevutes)
                    .HasForeignKey(d => d.Idscadenza)
                    .HasConstraintName("FK_Scadenze_Ricevute");
            });

            modelBuilder.Entity<Scadenze>(entity =>
            {
                entity.HasKey(e => e.Idscadenza);

                entity.ToTable("Scadenze");

                entity.Property(e => e.Idscadenza).HasColumnName("IDScadenza");

                entity.Property(e => e.Beneficiario)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DataPagamento).HasColumnType("datetime");

                entity.Property(e => e.DataScadenza).HasColumnType("datetime");

                entity.Property(e => e.Idbeneficiario).HasColumnName("IDBeneficiario");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Importo).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdbeneficiarioNavigation)
                    .WithMany(p => p.Scadenze)
                    .HasForeignKey(d => d.Idbeneficiario)
                    .HasConstraintName("FK_Scadenze_Beneficiario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
