using Fiap.Aula04.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Repositories
{
    public interface IVeiculoRepository
    {
        long Contar();

        void Cadastrar(Veiculo veiculo);

        void Atualizar(Veiculo veiculo);

        Veiculo Pesquisar(int id);

        List<Veiculo> Listar();

        List<Veiculo> BuscarPor(Expression<Func<Veiculo, bool>> filtro);

        void Remover(int id);

        void Salvar();
    }
}
