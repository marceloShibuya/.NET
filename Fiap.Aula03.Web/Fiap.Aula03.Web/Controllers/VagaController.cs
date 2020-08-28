using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula03.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Aula03.Web.Controllers
{
    public class VagaController : Controller
    {
        private static List<Vaga> _lista = new List<Vaga>();

        public IActionResult Index()
        {
            return View(_lista);
        }

        [HttpPost]
        public IActionResult Cadastrar(Vaga vaga)
        {
            _lista.Add(vaga);
            return RedirectToAction();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregaOpcoes();
            return View();
        }

        private void CarregaOpcoes()
        {
            List<string> listaEmpresa = new List<string>();
            listaEmpresa.Add("IBM");
            listaEmpresa.Add("HP");
            listaEmpresa.Add("Google");
            listaEmpresa.Add("Microsoft");

            ViewBag.empresas = new SelectList(listaEmpresa);
        }



    }
}
