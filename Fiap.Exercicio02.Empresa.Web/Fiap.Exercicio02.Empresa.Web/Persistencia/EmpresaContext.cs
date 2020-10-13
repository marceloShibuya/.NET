using Fiap.Exercicio02.Empresa.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.Persistencia
{
    public class EmpresaContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Instituicao> Instituicoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public EmpresaContext(DbContextOptions options) :base (options)
        {

        }
        

    }
}
