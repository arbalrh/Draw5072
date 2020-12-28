using System.Collections.Generic;
using System.Threading.Tasks;
using Facturacion.Entities;
using Facturacion.Entities.DTO;
using Facturacion.Entities.ViewModels;

namespace Facturacion.Service.Interfaces
{
    public interface IBodegas
    {
        IEnumerable<BodegaDTO> GetBodegas(GridRequest<BodegasFilters> gridRequest);
        Task<CommonResponse> CreateBodega(BodegaDTO bodega);
        Task<CommonResponse> DeleteBodega(string guid);
    }
}
