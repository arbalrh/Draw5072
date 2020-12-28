using System.Threading.Tasks;

namespace Facturacion.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICliente Clientes { get; }
        IBodega Bodega { get; }
        Task Commit();
    }
}
