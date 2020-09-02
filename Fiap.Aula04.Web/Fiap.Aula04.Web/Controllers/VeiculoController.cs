using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula04.Web.Models;
using Fiap.Aula04.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Aula04.Web.Controllers
{
    public class VeiculoController : Controller
    {
        private ConcessionariaContext _context;

        public VeiculoController(ConcessionariaContext context)
        {
            _context = context;
        }

        //Implementar o CRUD com o banco de dados

        public IActionResult Index()
        {
            return View(_context);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
           
            return RedirectToAction("Index");
        }


    }
}
