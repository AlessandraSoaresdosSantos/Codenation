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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Modelo> Get(int id)
        {
            Modelo modelo = _modeloService.ModeloById(id);

            if(modelo != null)
            {
                return Ok(modelo);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/modelo
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/modelo/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/modelo/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
        }
    }
}
