using System.Collections.Generic;
using System.Threading.Tasks;
using Facturacion.Entities;
using Facturacion.Entities.DTO;
using Facturacion.Entities.ViewModels;

namespace Facturacion.Service.Interfaces
{
    public interface IProductos
    {
        IEnumerable<ProductoDTO> GetProductos(GridRequest<ProductosFilters> gridRequest);
        Task<CommonResponse> CreateProducto(ProductoDTO producto);
        Task<CommonResponse> DeleteProducto(string guid);
    }
}
