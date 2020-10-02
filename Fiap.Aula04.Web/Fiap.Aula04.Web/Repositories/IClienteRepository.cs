using Fiap.Aula04.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);

        void Atualizar(Cliente cliente);

        Cliente Pesquisar(int id);

        Cliente PesquisarComVeiculos(int id);

        List<Cliente> Listar();

        List<Cliente> PesquisarPor(Expression<Func<Cliente, bool>> filtro);

        void Remover(int id);

        void Salvar();
    }
}
