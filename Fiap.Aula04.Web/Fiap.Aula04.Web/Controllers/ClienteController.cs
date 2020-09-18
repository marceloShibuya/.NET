using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula04.Web.Models;
using Fiap.Aula04.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //Método que recebe o id do cliente e envia os dados para a a tela de detalhes
        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            //Pesquisar o cliente, carregando os veículos
            var cliente = _context.Clientes.Include(c => c.Veiculos)
                .ThenInclude(c => c.Placa) // Carrega o relacionamento do veículo com a placa
                .Where(c => c.ClienteId == id)
                .FirstOrDefault(); //retorna o primeiro resultado ou null
            //Retorna o cliente para a view
            return View(cliente);
        }

    }
}
