using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Exercicio02.Empresa.Web.Models;
using Fiap.Exercicio02.Empresa.Web.Persistencia;
using Fiap.Exercicio02.Empresa.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Exercicio02.Empresa.Web.Controllers
{
    public class InstituicaoController : Controller
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController(IInstituicaoRepository instituicaoRepository)
        {
            _instituicaoRepository = instituicaoRepository;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Instituicao instituicao)
        {
            _instituicaoRepository.Cadastrar(instituicao);
            _instituicaoRepository.Salvar();
            TempData["msg"] = "Instituição cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
