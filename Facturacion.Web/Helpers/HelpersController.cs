using System.Collections.Generic;
using System.Linq;
using Facturacion.Entities.ViewModels;

namespace Facturacion.Web.Helpers
{
    public static class HelpersController
    {
        /// <summary>
        /// Retorna el objeto que necesita el Datatable para la carga de datos en el grid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="data"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public static GridResponse<U> GetGridResponse<T, U>(this GridRequest<T> data, IEnumerable<U> results)
            where T : class
            where U : GridTotal
        {
            var dataTable = new GridResponse<U>
            {
                draw = data.draw,
                recordsTotal = results != null && results.Any() ? results.First().TotalRows : 0,
                recordsFiltered = results != null && results.Any() ? results.First().TotalRows : 0,
                data = results,
                success = true
            };

            return dataTable;
        }
    }
}
