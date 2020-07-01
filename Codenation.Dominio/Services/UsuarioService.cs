using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public User GetByEmailPassword(Usuario usuario)
        {
           var result = _usuarioRepository.GetByEmailPassword(usuario);
            if(result != null)
            {
                User user = new User { 
                 ID = result.Email,
                  ChaveAcesso = result.Password,
                  Nivel = result.Nivel
                };
                return user;
            }

            return new User();
        }

    }
}
