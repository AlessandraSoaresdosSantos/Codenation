using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace Codenation.Dominio.Services
{
    public class UserProfileService : IProfileService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserProfileService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var request = context.ValidatedRequest as ValidatedTokenRequest;
            if (request != null)
            {
                var user = _usuarioRepository.Get().FirstOrDefault(x => x.Email == request.UserName);
                if (user != null)
                {
                    var claims = GetUserClaims(user);

                    context.IssuedClaims = claims
                        .Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                }
            }

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        public static Claim[] GetUserClaims(Usuario usuario)
        {
            string role = "User";

            if (usuario.Email == "tegglestone9@blog.com")
            {
                role = "Admin";
            }
            return new[]
            {
                new Claim(ClaimTypes.Email, usuario.Email ?? ""),
                new Claim(ClaimTypes.Role, role)
            };
        }

    }
}