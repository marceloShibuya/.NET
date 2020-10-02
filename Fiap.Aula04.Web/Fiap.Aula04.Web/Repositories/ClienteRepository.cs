using Fiap.Aula04.Web.Models;
using Fiap.Aula04.Web.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private ConcessionariaContext _context;

        public ClienteRepository(ConcessionariaContext context)
        {
            _context = context;
        }
        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }

        public Cliente Pesquisar(int id)
        {
            return _context.Clientes.Find(id);
        }

        //Método que pesquisa um cliente pelo ID e carrega os relacionamentos com veículo
        public Cliente PesquisarComVeiculos(int id)
        {
            return _context.Clientes
                .Include(c => c.Veiculos)
                .ThenInclude(c => c.Placa) // Carrega o relacionamento do veículo com a placa
                .Where(c => c.ClienteId == id)
                .FirstOrDefault(); //retorna o primeiro resultado ou null
        }

        public List<Cliente> PesquisarPor(Expression<Func<Cliente, bool>> filtro)
        {
            return _context.Clientes.Where(filtro).ToList();
        }

        public void Remover(int id)
        {
            var cliente = _context.Clientes.Find(id);
            _context.Clientes.Remove(cliente);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
