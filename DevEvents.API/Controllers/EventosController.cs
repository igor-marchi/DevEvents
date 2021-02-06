using DevEvents.API.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevEvents.API.Controllers
{
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterTodos()
        {
            var eventos = new List<Evento>
            {
                new Evento {Titulo = ".NET CORE", Descricao = "Venha prender tudo sober C#"},
                new Evento {Titulo = "Mobile", Descricao = "Venha aprender Mobile"}
            };
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterEvento(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Evento evento)
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