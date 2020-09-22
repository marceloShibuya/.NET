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

        public DbSet<Placa> Placas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<TestDrive> TestDrives { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela TestDrive
            modelBuilder.Entity<TestDrive>().HasKey(t => new { t.ClienteId, t.VeiculoId });

            //Configurar o relacionamento da tabela associativa com o cliente
            modelBuilder.Entity<TestDrive>().HasOne(t => t.Cliente).WithMany(t => t.TestDrives).HasForeignKey(t => t.ClienteId);

            //Configurar o relacionamento da tabela associativa com o Veiculo
            modelBuilder.Entity<TestDrive>().HasOne(t => t.Veiculo).WithMany(t => t.TestDrives).HasForeignKey(t => t.VeiculoId);

            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<EnderecoCliente>().HasKey(e => new { e.ClienteId, e.EnderecoId });

            //Configurar o relacionamento da tabela associativa com o cliente
            modelBuilder.Entity<EnderecoCliente>().HasOne(e => e.Cliente).WithMany(e => e.EnderecoClientes).HasForeignKey(e => e.ClienteId);

            //Configurar o relacionamento da tabela associativa com o endereço
            modelBuilder.Entity<EnderecoCliente>().HasOne(e => e.Cliente).WithMany(e => e.EnderecoClientes).HasForeignKey(e => e.EnderecoId);

            base.OnModelCreating(modelBuilder);
        }

        //Construtor que recebe algumas configurações como a string de conexão do DB
        public ConcessionariaContext(DbContextOptions options) : base (options)
        {

        }
    }
}
