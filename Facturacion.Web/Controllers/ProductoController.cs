using System.Threading.Tasks;
using Facturacion.Entities;
using Facturacion.Entities.DTO;
using Facturacion.Entities.ViewModels;
using Facturacion.Service.Interfaces;
using Facturacion.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facturacion.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductos producto;
        private readonly ILogger<ProductoController> logger;

        public ProductoController(IProductos producto, ILogger<ProductoController> logger)
        {
            this.producto = producto;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetProductosGrid([FromBody] GridRequest<ProductosFilters> gridRequest)
        {
            var results = producto.GetProductos(gridRequest);

            var gridResponse = gridRequest.GetGridResponse(results);

            return Json(gridResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductos([FromBody] ProductoDTO producto)
        {
            var results = await this.producto.CreateProducto(producto);

            return Json(results);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProducto([FromQuery] string guid)
        {
            var results = await this.producto.DeleteProducto(guid);

            return Json(results);
        }
    }
}
