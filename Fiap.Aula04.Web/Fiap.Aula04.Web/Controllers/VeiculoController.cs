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

        public IActionResult Index()
        {
            //Pesquisar todos os carros 1:10 no vídeo
            var lista = _context.Veiculos.ToList();
            return View(lista);
        }
    }
}
