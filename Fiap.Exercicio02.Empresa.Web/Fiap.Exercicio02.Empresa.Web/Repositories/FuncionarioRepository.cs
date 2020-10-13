using Fiap.Exercicio02.Empresa.Web.Models;
using Fiap.Exercicio02.Empresa.Web.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private EmpresaContext _context;

        public FuncionarioRepository(EmpresaContext context)
        {
            _context = context;
        }

        public void Atualizar(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
        }

        public Funcionario Buscar(int id)
        {
            return _context.Funcionarios.Find(id);
            
        }

        public IList<Funcionario> BuscarPor(Expression<Func<Funcionario, bool>> filtro)
        {
            return _context.Funcionarios.Where(filtro).Include(f => f.Instituicao).ToList();
        }

        public void Cadastrar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
        }

        public IList<Funcionario> Listar()
        {
            return _context.Funcionarios.Include(f => f.Instituicao).ToList();
            
        }

        public void Remover(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            _context.Funcionarios.Remove(funcionario);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
