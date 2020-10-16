using Fiap.Aula05.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula05.API.Persistencia
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public LojaContext(DbContextOptions options) : base (options)
        {

        }


    }

    
   
}
