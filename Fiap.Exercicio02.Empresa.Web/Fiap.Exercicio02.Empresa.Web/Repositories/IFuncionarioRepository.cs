using Fiap.Exercicio02.Empresa.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.Repositories
{
    public interface IFuncionarioRepository
    {
        void Cadastrar(Funcionario funcionario);

        void Atualizar(Funcionario funcionario);

        void Remover(int id);

        IList<Funcionario> Listar();

        IList<Funcionario> BuscarPor(Expression<Func<Funcionario, bool>> filtro);

        Funcionario Buscar(int id);

        void Salvar();
    }
}
