using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Codenation.Dominio.Entidades;
using Codenation.Dominio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Codenation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] User usuario,
                            [FromServices] UsuarioService usrService,
                            [FromServices] SigningConfigurations signingConfigurations)
        {
            bool credenciaisValidas = false;
            var usuarioBase = new User();

            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.ID))
            {
                Usuario user = new Usuario
                {
                    Email = usuario.ID,
                    Password = usuario.ChaveAcesso
                };

                usuarioBase = usrService.GetByEmailPassword(user);
                credenciaisValidas = (usuarioBase != null &&
                    usuario.ID == usuarioBase.ID &&
                    usuario.ChaveAcesso == usuarioBase.ChaveAcesso);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.ID, usuario.ID),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.ID),
                        new Claim(ClaimTypes.Role, usuarioBase.Nivel),
                        new Claim(ClaimTypes.Email, usuario.ID)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(3600);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = "ExemploIssuer",
                    Audience = "ExemploAudience",
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}