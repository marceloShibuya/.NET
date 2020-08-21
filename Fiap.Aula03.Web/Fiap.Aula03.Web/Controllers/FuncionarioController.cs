using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula03.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Aula03.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        //Simular o banco de dados
        private static List<Funcionario> _banco = new List<Funcionario>();

        //Listar todos os funcionários cadastrados
        public IActionResult Index()
        {
            //Enviar a lista de funcionários para a view
            return View(_banco);
        }
        
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        //Cadastrar o funcinonario na lista e retornar uma msg de sucesso
        //Não permitir o cadastrado novamente caso o usuario atualize a página de resposta
        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            funcionario.Codigo = _banco.Count + 1; //Count = size()
            _banco.Add(funcionario);
            TempData["msg"] = "Funcionário registrado";
            return RedirectToAction("Cadastrar");
        }

        //Método que recebe  o id do funcionário e retorna os valores do funcionário para a view
        [HttpGet]
        public IActionResult Editar(int id)
        {
            //Pesquisar o funcionário com o código informado
            var funcionario = _banco.Find(f => f.Codigo == id);
            //Enviar o funcionário para a view
            return View(funcionario);
        }
    }
}
