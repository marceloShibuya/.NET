﻿using System;
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

        //Injeção de dependência pelo construtor
        public VeiculoController(ConcessionariaContext context) 
        {
            _context = context;
        }

        //Implementar o CRUD com banco de dados!

        [HttpGet] //http://localhost:50461/veiculo/cadastrar
        public IActionResult Cadastrar()
        {
            return View(); //Abre a tela -> /View/Veiculo/Cadastrar.cshtml
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            TempData["msg"] = "Cadastrado com sucesso!";
            return RedirectToAction("Cadastrar"); //Redireciona para o método Cadastrar GET
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            return View(veiculo);
        }
        
        [HttpPost]
        public IActionResult Editar(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
            TempData["msg"] = "Veículo atualizado!";
            return RedirectToAction("Index");  
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
            TempData["msg"] = "Veículo removido!";
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

        public IActionResult Index(int ano)
        {
            //Contar a quantidade de veículos registrado
            var qtd = _context.Veiculos.Count();
            //Enviar a informação para a view
            ViewBag.qtd = qtd;
            //Pesquisar todos os carros ou pesquisar pelo ano
            var lista = _context.Veiculos.Where(v => v.Ano == ano || ano == 0).OrderBy(v => v.Modelo).ToList();
            return View(lista);
        }
    }
}
