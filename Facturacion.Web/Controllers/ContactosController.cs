using Facturacion.Entities;
using Facturacion.Entities.ViewModels;
using Facturacion.Service.Interfaces;
using Facturacion.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facturacion.Web.Controllers
{
    public class ContactosController : Controller
    {
        private readonly IContactos contactos;
        private readonly ILogger<ContactosController> logger;

        public ContactosController(IContactos contactos, ILogger<ContactosController> logger)
        {
            this.contactos = contactos;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetClientesGrid([FromBody] GridRequest<ContactosFilters> gridRequest)
        {
            var results = contactos.GetClientes(gridRequest);

            var gridResponse = gridRequest.GetGridResponse(results);

            return Json(gridResponse);
        }
    }
}
