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
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("buscar")]
        public IList<Cliente> Search(string nome)
        {
            return _clienteRepository.BuscarPor(c => c.Nome.Contains(nome));
        }

        [HttpGet]
        public IList<Cliente> Get()
        {
            return _clienteRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _clienteRepository.Buscar(id);
            if (cliente == null) return NotFound();
            return cliente;
        }

        [HttpPost]
        public ActionResult<Cliente> Post(Cliente cliente)
        {
            _clienteRepository.Cadastrar(cliente);
            _clienteRepository.Salvar();
            return CreatedAtAction("Get", new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult<Cliente> Put(int id, Cliente cliente)
        {
            var c = _clienteRepository.Buscar(id);
            if (c == null) return NotFound();

            cliente.ClienteId = id;
            _clienteRepository.Atualizar(cliente);
            _clienteRepository.Salvar();
            
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var c = _clienteRepository.Buscar(id);
            if (c == null) return NotFound();

            _clienteRepository.Remover(id);
            _clienteRepository.Salvar();

            return NoContent();
        }


    }
}
