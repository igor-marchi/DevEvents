using DevEvents.API.Entidades;
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
        [HttpGet]
        public IActionResult ObterTodos()
        {
            var uauarios = new List<Usuario>
            {
                new Usuario { NomeCompleto = "Claudio da Massa", DataNascimento = new DateTime(1990, 10, 21)},
                new Usuario { NomeCompleto = "Cleiton Raxta", DataNascimento = new DateTime(1990, 5, 11)},
                new Usuario { NomeCompleto = "Dreisson Rodrigues", DataNascimento = new DateTime(1980, 11, 30)},
            };
            return Ok(uauarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObterUsuario(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastar([FromBody] Usuario usuario)
        {
            return Ok();
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