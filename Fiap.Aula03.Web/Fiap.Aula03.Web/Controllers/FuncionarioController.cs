using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula03.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        //Cadastrar o funcinonario na lista e retornar uma msg de sucesso
        //Não permitir o cadastrado novamente caso o usuario atualize a página de resposta
        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            //Valida se existe elementos na lista
            if (_banco.Any())
            {
                funcionario.Codigo = _banco[_banco.Count - 1].Codigo + 1; //Count = size()
            }
            else
            {
                funcionario.Codigo = 1;
            }

            _banco.Add(funcionario);
            TempData["msg"] = "Funcionário registrado";
            return RedirectToAction("Cadastrar");
        }

        //Ajustar a listagem e edição para exibir e modificar o setor
        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregaSetores();
            return View();
        }

        private void CarregaSetores()
        {
            //Enviar os dados para preencher o select de setores da empresa
            List<string> lista = new List<string>();
            lista.Add("RH");
            lista.Add("Financeiro");
            lista.Add("TI");
            lista.Add("COmercial");

            ViewBag.setores = new SelectList(lista);
        }


        //Método que recebe  o id do funcionário e retorna os valores do funcionário para a view
        [HttpGet]
        public IActionResult Editar(int id)
        {
            //Envia os valores para preencher o select
            CarregaSetores();
            //Pesquisar o funcionário com o código informado
            var funcionario = _banco.Find(f => f.Codigo == id);
            //Enviar o funcionário para a view
            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Editar(Funcionario funcionario)
        {
            //Editar o funcionario(pesquisa o index do funcionário e substitui o objeto)
            _banco[_banco.FindIndex(f => f.Codigo == funcionario.Codigo)] = funcionario;
            //Mensagem de sucesso
            TempData["msg"] = "Funcionário atualizado!";
            //Redirect para a listagem
            return RedirectToAction("Index");
        }

        //Método que remove um funcionário
        [HttpPost]
        public IActionResult Remover(int id)
        {
            //Remove da lista(remove pelo index)
            _banco.RemoveAt(_banco.FindIndex(f => f.Codigo == id));
            //Mensagem de sucesso
            TempData["msg"] = "Funcionário demitido";
            //Redirect
            return RedirectToAction("Index");
        }
    }
}
