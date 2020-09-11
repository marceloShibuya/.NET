using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula04.Web.Models;
using Fiap.Aula04.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Aula04.Web.Controllers
{
    public class ClienteController : Controller
    {
        private ConcessionariaContext _context;

        public ClienteController(ConcessionariaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            TempData["msg"] = "Cliente cadastrado!";
            return RedirectToAction("Index");
        }

        public IActionResult Index(string nome)
        {
            var lista = _context.Clientes.Where(c => c.Nome.Contains(nome)|| string.IsNullOrEmpty(nome)).ToList();
            ViewBag.clientes = lista; //envia a lista de clientes para a view
            return View();
        }

    }
}
