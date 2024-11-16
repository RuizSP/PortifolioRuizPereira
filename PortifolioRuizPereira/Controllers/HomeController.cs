using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortifolioRuizPereira.Data;
using PortifolioRuizPereira.Models;
using System.Diagnostics;

namespace PortifolioRuizPereira.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortifolioRuizPereiraContext _context;

        public HomeController(ILogger<HomeController> logger, PortifolioRuizPereiraContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projetos = await _context.Projeto.ToListAsync();
            var model = new HomeViewModel() { Projetos = projetos}; 
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
