using Fiap.Aula05.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula05.API.Repositories
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);

        void Atualizar(Produto produto);

        void Remover(int id);

        Produto Buscar(int id);

        List<Produto> Listar();

        IList<Produto> BuscarPor(Expression<Func<Produto, bool>> filtro);

        void Salvar();


    }
}
