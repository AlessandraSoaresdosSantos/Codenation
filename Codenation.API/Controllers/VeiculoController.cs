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
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        // GET: api/veiculo
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Veiculo>> Get()
        {
            IList<Veiculo> veiculos = _veiculoService.Veiculos();

            if (veiculos.Any())
            {
                return Ok(veiculos);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/veiculo/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/veiculo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/veiculo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/veiculo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
