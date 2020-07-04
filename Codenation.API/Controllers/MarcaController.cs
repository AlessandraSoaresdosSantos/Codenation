using System.Collections.Generic;
using System.Linq;
using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User", Roles = "Comum")]
    [ApiController]    
    public class MarcaController : ControllerBase
    {

        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }


        // GET: api/marca
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Marca>> Get()
        {
            var marcas = _marcaService.Marcas().ToList();

            if (marcas.Any())
            {
                return Ok(marcas);
            }
            else
            {
                return NoContent();
            }

        }

        // GET api/marca/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Marca> Get(int id)
        {
            var marca = _marcaService.MarcaById(id);

            if (marca != null)
            {
                return Ok(marca);
            }
            else
            {
                return NoContent();
            }
        }


        // POST api/marca
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Marca> Post([FromBody] Marca marca)
        {
            var _marca = _marcaService.Salvar(marca);

            if (_marca != null)
            {
                return Ok(_marca);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT api/marca
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         public ActionResult<Marca> Put([FromBody] Marca marca)
        {
            var _marca = _marcaService.Atualizar(marca);

            if (_marca != null)
            {
                return Ok(_marca);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/marca/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var retorno = _marcaService.Deletar(id);

            if (retorno)
            {
                return Ok("Registro delatado com sucesso");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
