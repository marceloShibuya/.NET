using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula02.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Aula02.Web.Controllers
{
    public class ProdutoController : Controller
    {

        //localhost: 123/produto
        //localhost: 123/produto/index

        public IActionResult Index()
        {
            return View();
        }

        //Localhost: 123/produto/cadastrar -> abrir um formulário com
        //nome, preço e quantidade e um botão para enviar
        //Na primeira chamada é carregado essa URL
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        //Acionado no submit do formulário depois que é chamado a função acima
        [HttpPost]
        //public IActionResult Cadastrar(string nome, decimal preco, int quantidade)
        //{
            //return Content(nome + " " + preco + " " + quantidade);
            //return View();
        //}
          public IActionResult Cadastrar(Produto produto)
        {
            //return Content(produto.Nome + " " + produto.Preco + " " + produto.Quantidade );
            //Enviar valores para a View
            ViewData["chave"] = produto.Nome;
            ViewBag.prod = produto;

            return View(produto); //envia o objeto produto para a view

            //Manter as informações após um redirect
            //TempData["msg"] = "Cadastrado realizado com sucesso";
            //return RedirectToAction("Cadastrar");
        }



        


    }
}
