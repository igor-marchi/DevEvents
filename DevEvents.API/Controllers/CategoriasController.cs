using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevEvents.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;

        public CategoriasController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ObterTodas()
        {
            var categorais = _dbContext.Categorias.ToList();
            return Ok(categorais);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Categoria categoria)
        {
            if (categoria == null)
                throw new InvalidOperationException("Objeto categoria nulo");

            _dbContext.Categorias.Add(categoria);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}