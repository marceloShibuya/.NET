using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Aula05.API.Models;
using Fiap.Aula05.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Aula05.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // localhost/api/produto (GET) -> Listar os produtos
        [HttpGet]
        public IList<Produto> Get()
        {
            return _produtoRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _produtoRepository.Buscar(id);
            if (produto == null) 
                return NotFound();
            return produto;
            
        }



    }
}
