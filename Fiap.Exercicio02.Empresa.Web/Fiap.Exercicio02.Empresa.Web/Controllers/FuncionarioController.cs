﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Exercicio02.Empresa.Web.Models;
using Fiap.Exercicio02.Empresa.Web.Persistencia;
using Fiap.Exercicio02.Empresa.Web.Repositories;
using Fiap.Exercicio02.Empresa.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Exercicio02.Empresa.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        private IFuncionarioRepository _funcionarioRepository;

        private IInstituicaoRepository _instituicaoRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IInstituicaoRepository instituicaoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _instituicaoRepository = instituicaoRepository;
        }

        [HttpGet] 
        public IActionResult Cadastrar()
        {
            return View(CarregarModel());
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            // Validar se o funcionário está OK
            if (ModelState.IsValid)
            {
                _funcionarioRepository.Cadastrar(funcionario);
                _funcionarioRepository.Salvar();
                TempData["msg"] = "Funcionário cadastrado!";
                return RedirectToAction("Cadastrar");
            }
            else
            {
                return View(CarregarModel());
            }
        }

        private FuncionarioViewModel CarregarModel()
        {
            var model = new FuncionarioViewModel()
            {
                Instituicoes = new SelectList(_instituicaoRepository.Listar(), "InstituicaoId", "Nome")
            };

            return model;
        }

        public IActionResult Index()
        {
            var lista = _funcionarioRepository.Listar();
            return View(lista);
        }


    }
}
