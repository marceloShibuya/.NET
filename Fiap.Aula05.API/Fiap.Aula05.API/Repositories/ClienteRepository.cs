using Fiap.Aula05.API.Models;
using Fiap.Aula05.API.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula05.API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private LojaContext _context;

        public ClienteRepository(LojaContext context)
        {
            _context = context;
        }

        public void Atualizar(Cliente cliente)
        {
            var local = _context.Clientes.Local.FirstOrDefault(c => c.ClienteId == cliente.ClienteId);
            if (local != null) _context.Entry(local).State = EntityState.Detached;

            _context.Clientes.Update(cliente);
        }

        public Cliente Buscar(int id)
        {
            return _context.Clientes.Find(id);
        }

        public IList<Cliente> BuscarPor(Expression<Func<Cliente, bool>> filtro)
        {
            return _context.Clientes.Where(filtro).ToList();
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes.ToList();
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
