using System;
using Facturacion.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturacion.Repository.Contexts.Configuration
{
    public class AspNetPermissionsModelBuilder : IEntityTypeConfiguration<AspNetPermissions>
    {
        public void Configure(EntityTypeBuilder<AspNetPermissions> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired(true);
            builder.Property(s => s.Description).IsRequired(true);
            builder.Property(s => s.Type).IsRequired(true);
            builder.Property(s => s.OrderNo).IsRequired(true);
            builder.Property(s => s.ChildOf).IsRequired(false);
            builder.Property(s => s.Navigation).IsRequired(false);
            builder.Property(s => s.IconStyle).IsRequired(false);
            builder.Property(s => s.CreateUserId).IsRequired(true);
            builder.Property(s => s.UpdateUserId).IsRequired(false);
            builder.Property(s => s.DateCreated).IsRequired(true);
            builder.Property(s => s.DateUpdated).IsRequired(false);

#if DEBUG
            builder.HasData(new AspNetPermissions
            {
                Id = Guid.Parse("8bdab0fe-ede2-40f1-94d5-d1188631f7c2"),
                Name = "SECURITY",
                Description = "",
                Type = "MENU",
                OrderNo = 0,
                Navigation = "",
                CreateUserId = "ADMIN",
                DateCreated = DateTime.Now
            });
#endif
        }
    }
}
