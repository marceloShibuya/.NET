using Fiap.Aula04.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Persistencia
{
    public class ConcessionariaContext : DbContext 
    {
        //Propriedades -> Entidades
        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        //Construtor que recebe algumas configurações como a string de conexão do DB
        public ConcessionariaContext(DbContextOptions options) : base (options)
        {

        }
    }
}
