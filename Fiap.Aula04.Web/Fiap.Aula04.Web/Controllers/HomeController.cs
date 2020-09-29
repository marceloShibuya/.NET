using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fiap.Aula04.Web.Models;
using Fiap.Aula04.Web.Persistencia;

namespace Fiap.Aula04.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ConcessionariaContext _context;

        public HomeController(ILogger<HomeController> logger, ConcessionariaContext contex)
        {
            _context = contex;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.clientes = _context.Clientes.Count();
            ViewBag.veiculos = _context.Veiculos.Count();
            ViewBag.tests = _context.TestDrives.Count();
            return View();
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
