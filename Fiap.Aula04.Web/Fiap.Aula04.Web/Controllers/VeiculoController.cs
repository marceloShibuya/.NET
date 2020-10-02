using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula04.Web.Models;
using Fiap.Aula04.Web.Persistencia;
using Fiap.Aula04.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Aula04.Web.Controllers
{
    public class VeiculoController : Controller
    {
        private ConcessionariaContext _context;

        private IVeiculoRepository _veiculoRepository;

        private IClienteRepository _clienteRepository;

        //Injeção de dependência pelo construtor
        public VeiculoController(ConcessionariaContext context, IVeiculoRepository veiculoRepository, IClienteRepository clienteRepository)
        {
            _context = context;
            _veiculoRepository = veiculoRepository;
            _clienteRepository = clienteRepository;
    }

        //Método que recebe o id do veículo para exibir os clientes (test drive)
        public IActionResult ExibirCliente(int id)
        {
            //Lista de clientes
            var clientes = _context.TestDrives
                .Where(v => v.VeiculoId == id)
                .Select(v => v.Cliente)
                .ToList();

            ViewBag.clientes = clientes;

            //O veículo
            var veiculo = _veiculoRepository.Pesquisar(id);

            return View(veiculo);
        }

        //Implementar o CRUD com banco de dados!

        [HttpGet] //http://localhost:50461/veiculo/cadastrar
        public IActionResult Cadastrar()
        {
            CarregarClientes();
            return View(); //Abre a tela -> /View/Veiculo/Cadastrar.cshtml
        }

        private void CarregarClientes()
        {
            //Pesquisar todos os clientes
            var lista = _clienteRepository.Listar();
            //Enviar os clientes para preencher o select
            //lista, valor da option (PK), texto da option
            ViewBag.clientes = new SelectList(lista, "ClienteId", "Nome"); //ClienteID e Nome vêm da Model Cliente
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            //Cadastrar no banco
            _veiculoRepository.Cadastrar(veiculo);
            //Commit
            _veiculoRepository.Salvar();
            TempData["msg"] = "Cadastrado com sucesso!";
            return RedirectToAction("Cadastrar"); //Redireciona para o método Cadastrar GET
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarClientes();
            //Pesquisa o veículo pelo código
            var veiculo = _veiculoRepository.Pesquisar(id);
            return View(veiculo); //envia o veículo para a view
        }
        
        [HttpPost]
        public IActionResult Editar(Veiculo veiculo)
        {
            //Atualizar no banco
            _veiculoRepository.Atualizar(veiculo);
            //Commit
            _veiculoRepository.Salvar();
            TempData["msg"] = "Veículo atualizado!";
            return RedirectToAction("Index");  
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            //Cadastrar no banco
            _veiculoRepository.Remover(id);
            //Commit
            _veiculoRepository.Salvar();
            //Mensagem de sucesso
            TempData["msg"] = "Veículo removido!";
            //Redirect
            return RedirectToAction("Index");
        }

        /*
        [HttpGet]
        public IActionResult Pesquisar(int ano)
        {
            var lista = _context.Veiculos.Where(v => v.Ano == ano || ano == 0).OrderBy(v => v.Modelo).ToList();
            //Retornar para a página Index com a lista filtrada
            return View("Index", lista); //nome da página, a lista de veículos filtrada
        }
        */

        public IActionResult Index(int ano, string modelo, int cliente)
        {
            //Contar a quantidade de veículos registrado
            var qtd = _veiculoRepository.Contar();
            //Enviar a informação para a view
            ViewBag.qtd = qtd;

            //Enviar o select list para preencher o select de clientes
            //.Any() -> verifica se existe algum item na lista
            // pesquisa somente os clientes que possuem veículo
            var clientes = _clienteRepository.PesquisarPor(c => c.Veiculos.Any());

            //Enviar os clientes para preencher o select
            //clientes, valor da option (PK), texto da option
            ViewBag.clientes = new SelectList(clientes, "ClienteId", "Nome"); //ClienteID e Nome vêm da Model Cliente

            //Pesquisar todos os carros ou pesquisar pelo ano
            var lista = _veiculoRepository.BuscarPor(v => (v.Ano == ano || ano == 0)
                    && (v.Modelo.Contains(modelo) || string.IsNullOrEmpty(modelo))
                    && (v.ClienteId == cliente || cliente == 0));
          
            return View(lista); //enviar a lista de veiculo para a view
        }


    }
}
