using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Facturacion.Repository.Contexts.Configuration
{
    public class IdentityUserRoleModelBuilder : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
#if DEBUG
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            });
#endif
        }
    }
}
