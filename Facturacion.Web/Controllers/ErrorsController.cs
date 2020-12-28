using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.Web.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Error/500")]
        public IActionResult Error500()
        {
            _ = HttpContext.Items["isVerified"];

            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                //TODO: No Production
                ViewBag.TechErrorMessage = exceptionFeature.Error.Message;
                //
                ViewBag.RouteOfException = exceptionFeature.Path;
            }

            ViewBag.ErrorMessage = "Sorry something went wrong on the server";

            return View("Error");
        }

        [Route("Error/400")]
        public IActionResult Error400()
        {
            return View("Error");
        }
    }
}
