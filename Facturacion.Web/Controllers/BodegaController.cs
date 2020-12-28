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
    public class BodegaController : Controller
    {
        private readonly IBodegas bodega;
        private readonly ILogger<BodegaController> logger;

        public BodegaController(IBodegas bodega, ILogger<BodegaController> logger)
        {
            this.bodega = bodega;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetBodegasGrid([FromBody] GridRequest<BodegasFilters> gridRequest)
        {
            var results = bodega.GetBodegas(gridRequest);

            var gridResponse = gridRequest.GetGridResponse(results);

            return Json(gridResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBodega([FromBody] BodegaDTO bodega)
        {
            var results = await this.bodega.CreateBodega(bodega);

            return Json(results);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBodega([FromQuery] string guid)
        {
            var results = await this.bodega.DeleteBodega(guid);

            return Json(results);
        }
    }
}
