using System;
using Facturacion.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturacion.Repository.Contexts.Configuration
{
    public class AspNetRolePermissionsModelBuilder : IEntityTypeConfiguration<AspNetRolePermissions>
    {
        public void Configure(EntityTypeBuilder<AspNetRolePermissions> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.IdentityRoleId).IsRequired(true);
            builder.Property(s => s.PermissionId).IsRequired(true);
            builder.Property(s => s.CreateUserId).IsRequired(true);
            builder.Property(s => s.UpdateUserId).IsRequired(false);
            builder.Property(s => s.DateCreated).IsRequired(true);
            builder.Property(s => s.DateUpdated).IsRequired(false);
            builder.HasOne(s => s.Permission)
                   .WithMany(s => s.AspNetRolePermissions)
                   .HasForeignKey(fk => fk.PermissionId);

#if DEBUG
            builder.HasData(new AspNetRolePermissions
            {
                Id = Guid.Parse("4b42c9be-d71f-49cf-8f66-19e30d6e49d1"),
                PermissionId = Guid.Parse("8bdab0fe-ede2-40f1-94d5-d1188631f7c2"),
                IdentityRoleId = "1",
                CreateUserId = "ADMIN",
                DateCreated = DateTime.Now
            });
#endif
        }
    }
}
