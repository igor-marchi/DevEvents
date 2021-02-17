using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
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
            //EF Core
            var categorias = _dbContext.Categorias.ToList();

            //Dapper
            //var connectionString = _dbContext.Database.GetDbConnection().ConnectionString;

            //using SqlConnection sqlConnection = new SqlConnection(connectionString);
            //var script = "SELECT * FROM Categorias";
            //var categorias = sqlConnection.Query<Categoria>(script);

            return Ok(categorias);
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