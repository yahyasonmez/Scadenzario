﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scadenzario.Models.Services.Infrastructure;

namespace Scadenzario.Migrations
{
    [DbContext(typeof(MyScadenzaDbContext))]
    [Migration("20210326122235_AddRelazioni")]
    partial class AddRelazioni
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Latin1_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.Beneficiario", b =>
                {
                    b.Property<int>("IDBeneficiario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Descrizione");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Email");

                    b.Property<string>("Sbeneficiario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Beneficiario");

                    b.Property<string>("SitoWeb")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("SitoWeb");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Telefono");

                    b.HasKey("IDBeneficiario");

                    b.ToTable("Beneficiari");
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.Ricevuta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beneficiario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Beneficiario");

                    b.Property<byte[]>("FileContent")
                        .IsRequired()
                        .HasColumnType("image")
                        .HasColumnName("FileContent");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("FileName");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("FileType");

                    b.Property<int>("IDScadenza")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Path");

                    b.HasKey("Id");

                    b.HasIndex("IDScadenza");

                    b.ToTable("Ricevute");
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.Scadenza", b =>
                {
                    b.Property<int>("IDScadenza")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beneficiario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Beneficiario");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime")
                        .HasColumnName("DataPagamento");

                    b.Property<DateTime>("DataScadenza")
                        .HasColumnType("datetime")
                        .HasColumnName("DataScadenza");

                    b.Property<short?>("GiorniRitardo")
                        .HasColumnType("smallint")
                        .HasColumnName("GiorniRitardo");

                    b.Property<int>("IDBeneficiario")
                        .HasColumnType("int");

                    b.Property<string>("IDUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Importo")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Sollecito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("Sollecito");

                    b.HasKey("IDScadenza");

                    b.HasIndex("IDBeneficiario");

                    b.HasIndex("IDUser");

                    b.ToTable("Scadenze");
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.Ricevuta", b =>
                {
                    b.HasOne("Scadenzario.Models.Entities.Scadenza", "Scadenza")
                        .WithMany("Ricevute")
                        .HasForeignKey("IDScadenza")
                        .HasConstraintName("FK_Scadenze_Ricevute")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scadenza");
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.Scadenza", b =>
                {
                    b.HasOne("Scadenzario.Models.Entities.Beneficiario", "beneficiario")
                        .WithMany("Scadenze")
                        .HasForeignKey("IDBeneficiario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scadenzario.Models.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Scadenze")
                        .HasForeignKey("IDUser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ApplicationUser");

                    b.Navigation("beneficiario");
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.Beneficiario", b =>
                {
                    b.Navigation("Scadenze");
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.Scadenza", b =>
                {
                    b.Navigation("Ricevute");
                });

            modelBuilder.Entity("Scadenzario.Models.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Scadenze");
                });
#pragma warning restore 612, 618
        }
    }
}
