using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
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

        // /api/produto/buscar?nome=teste (GET) -> pesquisa por nome
        [HttpGet("buscar")]
        public IList<Produto> Get(string nome)
        {
            return _produtoRepository.BuscarPor(p => p.Nome.Contains(nome));
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
                return NotFound(); //404
            return produto;
        }

        // /api/produto (POST) -> Cadastrar
        [HttpPost]
        public ActionResult<Produto> Post(Produto produto)
        {
            _produtoRepository.Cadastrar(produto);
            _produtoRepository.Salvar();
            //Response 201 Created, os dados do produto salvo e o link para acessar o produto cadastrado
            return CreatedAtAction("Get", new { id = produto.ProdutoId}, produto);
        }

        // /api/produto/1 (PUT) -> Atualizar
        [HttpPut("{id}")]
        public ActionResult<Produto> Put(int id, Produto produto)
        {
           var p = _produtoRepository.Buscar(id);
            if (p == null) return NotFound(); //404

            produto.ProdutoId = id;
            _produtoRepository.Atualizar(produto);
            _produtoRepository.Salvar();

            return Ok(produto);
        }


        // /api/produto/1 (DELETE) -> Remover
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _produtoRepository.Buscar(id);
            if (p == null) return NotFound();

            _produtoRepository.Remover(id);
            _produtoRepository.Salvar();

            return NoContent(); //204 No Content
        }


    }
}
