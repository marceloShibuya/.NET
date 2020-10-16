using Fiap.Aula05.API.Models;
using Fiap.Aula05.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula05.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private LojaContext _context;

        public ProdutoRepository(LojaContext context)
        {
            _context = context;
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public Produto Buscar(int id)
        {
            return _context.Produtos.Find(id);
        }

        public IList<Produto> BuscarPor(Expression<Func<Produto, bool>> filtro)
        {
            return _context.Produtos.Where(filtro).ToList();
        }

        public List<Produto> Listar()
        {
            return _context.Produtos.ToList();
        }

        public void Remover(int id)
        {
            _context.Produtos.Remove(_context.Produtos.Find(id));

            //var produto = _context.Produtos.Find(id);
            //_context.Produtos.Remove(produto);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
