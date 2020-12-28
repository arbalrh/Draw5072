using Facturacion.Entities.DTO;
using Facturacion.Repository.Entities;

namespace Facturacion.Repository.Interfaces
{
    public interface IBodega : IRepositoryBase<Bodega>
    {
        void CreateBodega(BodegaDTO bodega);
        void DeleteBodega(string guid);
    }
}
