using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevEvents.API.Controllers
{
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;

        public EventosController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var eventos = _dbContext.Eventos.ToList();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterEvento(int id)
        {
            var evento = _dbContext.
                Eventos
                .Include(e => e.Categoria)
                .Include(e => e.Usuario)
                .Include(e => e.Inscricoes)
                .SingleOrDefault(e => e.Id == id);

            if (evento == null)
                return NotFound();

            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Evento evento)
        {
            _dbContext.Eventos.Add(evento);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Evento evento)
        {
            var eventoBanco = _dbContext.Eventos.SingleOrDefault(e => e.Id == id);

            eventoBanco.Ativo = evento.Ativo;
            eventoBanco.Descricao = evento.Descricao;

            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var evento = _dbContext.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();

            evento.Ativo = false;
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPost("{idEvento}/usuarios/{idUsuario}/inscrever")]
        public IActionResult Inscrever(int idEvento, int idUsuario, [FromBody] Inscricao inscricao)
        {
            if (inscricao == null)
                throw new InvalidOperationException("Objeto Inscricao está vazio");

            var evento = _dbContext.Eventos.SingleOrDefault(e => e.Id == idEvento);
            if (evento == null)
                return BadRequest();

            _dbContext.Inscricoes.Add(inscricao);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPost("pupular")]
        public IActionResult Popular()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario { NomeCompleto = "Claudio da Massa", DataNascimento = new DateTime(1990, 10, 21)},
                new Usuario { NomeCompleto = "Cleiton Raxta", DataNascimento = new DateTime(1990, 5, 11)},
                new Usuario { NomeCompleto = "Dreisson Rodrigues", DataNascimento = new DateTime(1980, 11, 30)},
            };

            var categorais = new List<Categoria>
            {
                new Categoria { Descricao = "Mobile"},
                new Categoria { Descricao = ".NET CORE"},
                new Categoria { Descricao = "Machine Learning"},
            };

            _dbContext.Usuarios.AddRange(usuarios);
            _dbContext.Categorias.AddRange(categorais);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}