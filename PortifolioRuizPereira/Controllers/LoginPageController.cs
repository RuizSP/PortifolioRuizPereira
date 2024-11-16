using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PortifolioRuizPereira.Data;
using PortifolioRuizPereira.Models;
using System.Security.Claims;

namespace PortifolioRuizPereira.Controllers
{
    public class LoginPageController : Controller
    {
        private readonly PortifolioRuizPereiraContext _context;
        public LoginPageController(PortifolioRuizPereiraContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.LoginError = "Nome de usuário ou senha inválidos";
                return View(model);
            }

            var user = _context.Usuario.FirstOrDefault(u => u.Email == model.Login);
            if (user == null)
            {
                return View();
            }

            var clains = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role!),
            };

            var identity = new ClaimsIdentity(clains, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
