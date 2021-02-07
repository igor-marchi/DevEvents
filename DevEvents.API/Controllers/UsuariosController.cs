using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;

        public UsuariosController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var uauarios = _dbContext.Usuarios.ToList();
            return Ok(uauarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObterUsuario(int id)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(e => e.Id == id);
            if (usuario == null)
                return NoContent();

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Cadastar([FromBody] Usuario usuario)
        {
            if (usuario == null)
                throw new InvalidOperationException("Objeto usuario nulo");

            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            return NoContent();
        }
    }
}