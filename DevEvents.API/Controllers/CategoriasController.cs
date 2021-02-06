using DevEvents.API.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevEvents.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterTodas()
        {
            var categorais = new List<Categoria>
            {
                new Categoria { Descricao = "Mobile"},
                new Categoria { Descricao = ".NET CORE"},
                new Categoria { Descricao = "Machine Learning"},
            };
            return Ok(categorais);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Categoria categoria)
        {
            return Ok();
        }
    }
}