using System.Linq;
using System.Threading.Tasks;
using Facturacion.Entities;
using Facturacion.Repository.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Users()
        {
            return View($"~/Views/Account/{nameof(AccountController.Users)}/Index.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserRegister model)
        {
            var response = new CommonResponse();
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                response.Status = CommonResponseTypeStatus.success.ToString();
                response.Message = CommonResponseTypeStatus.success.ToString();

                return Ok(response);
            }
            else
            {
                response.Status = CommonResponseTypeStatus.error.ToString();
                response.Message = string.Join(", ", result.Errors.Select(s => s.Description).ToList());

                return BadRequest(response);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(UserLogin userLogin, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var result = await signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, userLogin.IsPersistent, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }
            }

            ModelState.AddModelError(nameof(userLogin.Email), "Login Failed: Invalid Email or password");

            return View(userLogin);
        }

        public async Task<IActionResult> LogOut(string returnUrl = null)
        {
            await signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
