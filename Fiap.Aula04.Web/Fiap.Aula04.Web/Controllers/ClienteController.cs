using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula04.Web.Models;
using Fiap.Aula04.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        //Método que cadastrar o relacionamento muitos para muitos
        [HttpPost]
        public IActionResult Teste (TestDrive testDrive)
        {
            //Cadastrar
            _context.TestDrives.Add(testDrive);
            //Commit
            _context.SaveChanges();
            //Mensagem
            TempData["msg"] = "Test Drive agendado";
            //Redirect para o Teste informando o id do cliente
            return RedirectToAction("Teste", new { id = testDrive.ClienteId});
        }

        //Método que recebe o id do cliente e envia para a view de test drive
        [HttpGet]
        public IActionResult Teste(int id)
        {
            //Enviar a lista de veículos de test drive do cliente
            var veiculos = _context.TestDrives
                .Where(c => c.ClienteId == id)
                .Select(c => c.Veiculo) //Seleciona o veículo do test drive
                .ToList();

            //Enviar a lista de test drives
            ViewBag.lista = veiculos;

            //Pesquisar todos os veículos que permite o test drive
            var lista = _context.Veiculos
                .Where(v => v.TestDrive) //pesquisa somente os TestDrive == true
                .ToList();

            //Filtrar a lista somente com os veículos que o cliente ainda não fez o test drive
            var listaFiltrada = lista.Where(c => !veiculos.Any(c1 => c1.VeiculoId == c.VeiculoId));

            //Enviar o select list de veículos para o select
            ViewBag.veiculos = new SelectList(listaFiltrada, "VeiculoId", "Modelo");

            //Pesquisar o cliente por id
            var cliente = _context.Clientes.Find(id);

            //Retornar o cliente para a view
            return View(cliente);
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
