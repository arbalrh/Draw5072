using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.Entities;
using Facturacion.Entities.DTO;
using Facturacion.Entities.ViewModels;
using Facturacion.Repository.Contexts;
using Facturacion.Repository.Entities;
using Facturacion.Service.Interfaces;
using Facturacion.Utils;
using Microsoft.Extensions.Logging;

namespace Facturacion.Service
{
    public class Bodegas : IBodegas
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<Bodegas> _logger;

        public Bodegas(ApplicationDbContext applicationDbContext, ILogger<Bodegas> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public IEnumerable<BodegaDTO> GetBodegas(GridRequest<BodegasFilters> gridRequest)
        {
            //Consulta
            var query = _applicationDbContext.Bodega.AsQueryable()
                        .Select(s => new
                        {
                            s.BodegaId,
                            s.Nombre,
                            s.Direccion,
                            s.Observaciones
                        });

            //Filtros
            if (!string.IsNullOrEmpty(gridRequest.filters.Nombre))
            {
                query = query.Where(w => w.Nombre.Trim().ToUpper().Contains(gridRequest.filters.Nombre.Trim().ToUpper()));
            }
            if (!string.IsNullOrEmpty(gridRequest.filters.Direccion))
            {
                query = query.Where(w => w.Direccion.Trim().ToUpper().Contains(gridRequest.filters.Direccion.Trim().ToUpper()));
            }

            //OrderBy
            if (gridRequest.order != null)
            {
                var ColumnIndex = gridRequest.order.First().column;
                var ColumnName = gridRequest.columns[ColumnIndex].data;
                var ColumnOrder = gridRequest.order.First().dir.ToUpper() == "ASC" ? ORDER.ASC : ORDER.DESC;

                ColumnName = new BodegaDTO().GetDBNamePropertyAttributeInSearch(ColumnName);

                query = query.OrderBy(ColumnName, ColumnOrder);
            }
            else
            {
                query = query.OrderBy(o => o.Nombre);
            }

            var count = query.Count();

            var results = query
                         .GetPage(gridRequest.page, gridRequest.length)
                         .Select(s => new BodegaDTO
                         {
                             BodegaId = s.BodegaId,
                             Nombre = s.Nombre,
                             Direccion = s.Direccion,
                             Observaciones = s.Observaciones,
                             TotalRows = count
                         })
                         .ToList();

            return results;
        }

        public async Task<CommonResponse> CreateBodega(BodegaDTO bodega)
        {
            var response = new CommonResponse();

            var entity = new Bodega
            {
                Nombre = bodega.Direccion?.Trim(),
                Direccion = bodega.Direccion?.Trim(),
                Observaciones = bodega.Observaciones?.Trim()
            };
            _applicationDbContext.Bodega.Add(entity);
            await _applicationDbContext.SaveChangesAsync();

            response.Status = CommonResponseTypeStatus.success.ToString();
            response.Message = CommonMessages.TRANSACCION_COMPLETADA;

            return response;
        }

        public async Task<CommonResponse> DeleteBodega(string guid)
        {
            var response = new CommonResponse();

            var entity = new Bodega
            {
                BodegaId = Guid.Parse(guid)
            };
            _applicationDbContext.Bodega.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();

            response.Status = CommonResponseTypeStatus.success.ToString();
            response.Message = CommonMessages.TRANSACCION_COMPLETADA;

            return response;
        }
    }
}
