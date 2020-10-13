using Fiap.Exercicio02.Empresa.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Exercicio02.Empresa.Web.Repositories
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao instituicao);

        void Atualizar(Instituicao instituicao);

        Instituicao Buscar(int id);

        IList<Instituicao> Listar();

        IList<Instituicao> BuscarPor(Expression<Func<Instituicao, bool>> filtro);

        void Remover(int id);

        void Salvar();
    }
}
