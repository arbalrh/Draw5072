using System.Reflection;
using Facturacion.Repository.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Repository.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Bodega> Bodega { get; set; }
        public virtual DbSet<AspNetPermissions> AspNetPermissions { get; set; }
        public virtual DbSet<AspNetRolePermissions> AspNetRolePermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasPostgresExtension("pg_buffercache")
            //    .HasPostgresExtension("pg_stat_statements")
            //    .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.ClienteId)
                    .HasColumnName("clienteid")
                    .HasDefaultValueSql("UUID()");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(60);

                entity.Property(e => e.Identificacion)
                    .HasColumnName("identificacion")
                    .HasMaxLength(60);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(60);

                entity.Property(e => e.Telefono1)
                    .HasColumnName("telefono1")
                    .HasMaxLength(60);

                entity.Property(e => e.Telefono2)
                    .HasColumnName("telefono2")
                    .HasMaxLength(60);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(60);

                entity.Property(e => e.Celular)
                    .HasColumnName("celular")
                    .HasMaxLength(60);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.ToTable("bodega");

                entity.Property(e => e.BodegaId)
                    .HasColumnName("bodegaid")
                    .HasDefaultValueSql("UUID()");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(200);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(300);
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
