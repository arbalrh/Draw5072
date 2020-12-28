using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.Entities;
using Facturacion.Entities.DTO;
using Facturacion.Entities.ViewModels;
using Facturacion.Repository.Contexts;
using Facturacion.Service.Interfaces;
using Facturacion.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Facturacion.Service
{
    public class Contactos : IContactos
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<Bodegas> _logger;

        public Contactos(ApplicationDbContext applicationDbContext, ILogger<Bodegas> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<CommonResponse<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var response = new CommonResponse<IEnumerable<ClienteDTO>>
            {
                Data = await _applicationDbContext.Cliente
                                .AsNoTracking()
                                .Select(s => new ClienteDTO
                                {
                                    Nombre = s.Nombre
                                })
                                .ToListAsync(),

                Status = CommonResponseTypeStatus.success.ToString()
            };

            return response;
        }

        public IEnumerable<ClienteDTO> GetClientes(GridRequest<ContactosFilters> gridRequest)
        {
            //Consulta
            var query = _applicationDbContext.Cliente.AsQueryable()
                        .Select(s => new
                        {
                            s.ClienteId,
                            s.Nombre,
                            s.Identificacion,
                            s.Telefono1,
                            s.Telefono2
                        });

            //Filtros
            if (!string.IsNullOrEmpty(gridRequest.filters.Nombre))
            {
                query = query.Where(w => w.Nombre.Trim().ToUpper().Contains(gridRequest.filters.Nombre.Trim().ToUpper()));
            }

            //OrderBy
            if (gridRequest.order != null)
            {
                var ColumnIndex = gridRequest.order.First().column;
                var ColumnName = gridRequest.columns[ColumnIndex].data;
                var ColumnOrder = gridRequest.order.First().dir.ToUpper() == "ASC" ? ORDER.ASC : ORDER.DESC;

                ColumnName = new ClienteDTO().GetDBNamePropertyAttributeInSearch(ColumnName);

                query = query.OrderBy(ColumnName, ColumnOrder);
            }
            else
            {
                query = query.OrderBy(o => o.Nombre);
            }

            var count = query.Count();

            var results = query
                         .GetPage(gridRequest.page, gridRequest.length)
                         .Select(s => new ClienteDTO
                         {
                             ClienteId = s.ClienteId,
                             Nombre = s.Nombre,
                             Identificacion = s.Identificacion,
                             Telefono1 = s.Telefono1,
                             Telefono2 = s.Telefono2,
                             TotalRows = count
                         })
                         .ToList();

            //Fake
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });
            results.Add(new ClienteDTO { Nombre = "David", Identificacion = "8-888-888", Telefono1 = "123456", Telefono2 = "78910", TotalRows = 20 });

            return results;
        }
    }
}
