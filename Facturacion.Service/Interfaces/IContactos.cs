using System.Collections.Generic;
using System.Threading.Tasks;
using Facturacion.Entities;
using Facturacion.Entities.DTO;
using Facturacion.Entities.ViewModels;

namespace Facturacion.Service.Interfaces
{
    public interface IContactos
    {
        Task<CommonResponse<IEnumerable<ClienteDTO>>> GetClientes();
        IEnumerable<ClienteDTO> GetClientes(GridRequest<ContactosFilters> gridRequest);
    }
}
