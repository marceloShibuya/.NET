using Fiap.Aula05.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula05.API.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);

        void Atualizar(Cliente cliente);

        void Remover(int id);

        Cliente Buscar(int id);

        List<Cliente> Listar();

        IList<Cliente> BuscarPor(Expression<Func<Cliente, bool>> filtro);

        void Salvar();
    }
}
