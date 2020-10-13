using Fiap.Exercicio02.Empresa.Web.Models;
using Fiap.Exercicio02.Empresa.Web.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private EmpresaContext _context;

        public InstituicaoRepository(EmpresaContext context)
        {
            _context = context;
        }

        public void Atualizar(Instituicao instituicao)
        {
            _context.Instituicoes.Update(instituicao);
        }

        public Instituicao Buscar(int id)
        {
            return _context.Instituicoes.Find(id);
        }

        public IList<Instituicao> BuscarPor(Expression<Func<Instituicao, bool>> filtro)
        {
            return _context.Instituicoes.Where(filtro).ToList();
        }

        public void Cadastrar(Instituicao instituicao)
        {
            _context.Instituicoes.Add(instituicao);
        }

        public IList<Instituicao> Listar()
        {
            return _context.Instituicoes.ToList();
            
        }

        public void Remover(int id)
        {
            var instituicao = _context.Instituicoes.Find(id);
            _context.Instituicoes.Remove(instituicao);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
