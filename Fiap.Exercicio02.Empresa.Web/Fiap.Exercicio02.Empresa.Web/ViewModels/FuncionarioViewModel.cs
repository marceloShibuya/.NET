using Fiap.Exercicio02.Empresa.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.ViewModels
{
    public class FuncionarioViewModel
    {
        public Funcionario Funcionario { get; set; }

        public SelectList Instituicoes { get; set; }
    }
}
