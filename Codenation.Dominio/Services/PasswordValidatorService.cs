using Codenation.Dominio.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;
namespace Codenation.Dominio.Services
{
    public class PasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public PasswordValidatorService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
             var user = _usuarioRepository.GetByEmail(context.UserName);

            if (user != null && user.Password == context.Password)
            {
                context.Result = new GrantValidationResult(
                    subject: user.ID.ToString(),
                    authenticationMethod: "custom",
                    claims: UserProfileService.GetUserClaims(user)
                );
            }
            else
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
            return Task.CompletedTask;
        }

    }
}