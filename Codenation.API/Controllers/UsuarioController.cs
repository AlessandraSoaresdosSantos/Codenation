using Codenation.Dominio.Entidades;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Codenation.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IProfileService _iprofileService;

        public UsuarioController(IProfileService profileService)
        {
            _iprofileService = profileService;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            return " << Controlador UsuariosController :: WebApiUsuarios >> ";
        }
         
         
    }
}