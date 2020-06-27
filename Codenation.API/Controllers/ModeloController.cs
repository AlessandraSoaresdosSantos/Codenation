using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

 namespace Codenation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        // GET: api/modelo
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Modelo>> Get()
        {
            IList<Modelo> modelos = _modeloService.Modelos();

            if (modelos.Any())
            {
                return Ok(modelos);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/modelo/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/modelo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/modelo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/modelo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
