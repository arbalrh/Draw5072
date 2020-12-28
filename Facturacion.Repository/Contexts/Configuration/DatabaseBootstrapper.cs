using Facturacion.Repository.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Repository.Contexts.Configuration
{
    public class DatabaseBootstrapper : IDatabaseBootstrapper
    {
        private readonly ApplicationDbContext context;

        public DatabaseBootstrapper(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Configure()
        {
            context.Database.Migrate();
        }
    }
}
