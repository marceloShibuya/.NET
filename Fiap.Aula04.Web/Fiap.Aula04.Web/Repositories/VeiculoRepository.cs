using Fiap.Aula04.Web.Models;
using Fiap.Aula04.Web.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Aula04.Web.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {

        private ConcessionariaContext _context;

        public VeiculoRepository(ConcessionariaContext context)
        {
            _context = context;
        }

        public void Atualizar(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
        }

        public List<Veiculo> BuscarPor(Expression<Func<Veiculo, bool>> filtro)
        {
            return _context.Veiculos.Where(filtro).Include(v => v.Cliente).Include(v => v.Placa).ToList();
        }

        public void Cadastrar(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
        }

        public List<Veiculo> Listar()
        {
            return _context.Veiculos.Include(v => v.Placa).Include(v => v.Cliente).ToList();
        }

        public Veiculo Pesquisar(int id)
        {
            return _context.Veiculos.Include(v => v.Cliente).Include(v => v.Placa).Where(v => v.VeiculoId == id).FirstOrDefault();
        }

        public void Remover(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            _context.Veiculos.Remove(veiculo);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
