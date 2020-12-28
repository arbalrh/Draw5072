﻿// <auto-generated />
using System;
using Facturacion.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Facturacion.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211116001355_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Facturacion.Repository.Contexts.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e3ccdf98-f525-4b3e-8b66-92be4ba4f7f6",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHzivtJphQ4N2qp2hyL4/33bMehAOMHS0MgHxLXvnWrai511GVsj38x3Co44/CZ6yg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "546174b4-ad3b-428a-bcae-26cbfb67eb2f",
                            TwoFactorEnabled = false,
                            UserName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Facturacion.Repository.Entities.AspNetPermissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ChildOf")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ChildOfNavigationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IconStyle")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Navigation")
                        .HasColumnType("longtext");

                    b.Property<int?>("OrderNo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UpdateUserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ChildOfNavigationId");

                    b.ToTable("AspNetPermissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8bdab0fe-ede2-40f1-94d5-d1188631f7c2"),
                            CreateUserId = "ADMIN",
                            DateCreated = new DateTime(2021, 11, 15, 19, 13, 54, 872, DateTimeKind.Local).AddTicks(3160),
                            Description = "",
                            Name = "SECURITY",
                            Navigation = "",
                            OrderNo = 0,
                            Type = "MENU"
                        });
                });

            modelBuilder.Entity("Facturacion.Repository.Entities.AspNetRolePermissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IdentityRoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UpdateUserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdentityRoleId");

                    b.HasIndex("PermissionId");

                    b.ToTable("AspNetRolePermissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b42c9be-d71f-49cf-8f66-19e30d6e49d1"),
                            CreateUserId = "ADMIN",
                            DateCreated = new DateTime(2021, 11, 15, 19, 13, 54, 875, DateTimeKind.Local).AddTicks(8991),
                            IdentityRoleId = "1",
                            PermissionId = new Guid("8bdab0fe-ede2-40f1-94d5-d1188631f7c2")
                        });
                });

            modelBuilder.Entity("Facturacion.Repository.Entities.Bodega", b =>
                {
                    b.Property<Guid>("BodegaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("bodegaid")
                        .HasDefaultValueSql("UUID()");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("direccion");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("observaciones");

                    b.HasKey("BodegaId");

                    b.ToTable("bodega");
                });

            modelBuilder.Entity("Facturacion.Repository.Entities.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("clienteid")
                        .HasDefaultValueSql("UUID()");

                    b.Property<string>("Celular")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("celular");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("email");

                    b.Property<string>("Fax")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("fax");

                    b.Property<DateTime>("FechaActulizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Identificacion")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("identificacion");

                    b.Property<string>("Nombre")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("nombre");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("observaciones");

                    b.Property<string>("Telefono1")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("telefono1");

                    b.Property<string>("Telefono2")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("telefono2");

                    b.HasKey("ClienteId");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "f11b096c-fbc9-4b56-98fd-71d8560c6f54",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Facturacion.Repository.Entities.AspNetPermissions", b =>
                {
                    b.HasOne("Facturacion.Repository.Entities.AspNetPermissions", "ChildOfNavigation")
                        .WithMany("InverseChildOfNavigation")
                        .HasForeignKey("ChildOfNavigationId");

                    b.Navigation("ChildOfNavigation");
                });

            modelBuilder.Entity("Facturacion.Repository.Entities.AspNetRolePermissions", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "AspNetRole")
                        .WithMany()
                        .HasForeignKey("IdentityRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Facturacion.Repository.Entities.AspNetPermissions", "Permission")
                        .WithMany("AspNetRolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AspNetRole");

                    b.Navigation("Permission");
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
                    b.HasOne("Facturacion.Repository.Contexts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Facturacion.Repository.Contexts.ApplicationUser", null)
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

                    b.HasOne("Facturacion.Repository.Contexts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Facturacion.Repository.Contexts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Facturacion.Repository.Entities.AspNetPermissions", b =>
                {
                    b.Navigation("AspNetRolePermissions");

                    b.Navigation("InverseChildOfNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
