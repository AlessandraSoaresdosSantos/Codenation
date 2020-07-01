using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using Codenation.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codenation.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext context;
        public UsuarioRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Usuario> Get()
        {
            return context.Usuarios;
        }
        public Usuario GetById(int Id)
        {
            return context.Usuarios.Where(x => x.ID == Id).FirstOrDefault();
        }
        public Usuario GetByEmailPassword(Usuario usuario)
        {
            return context.Usuarios.Where(x => x.Email == usuario.Email &&
                                           x.Password == usuario.Password).FirstOrDefault();
        }
        public Usuario GetByEmail(string email)
        {
            return context.Usuarios.Where(x => x.Email == email).FirstOrDefault();
        }
        
        public Usuario Save(Usuario usuario)
        {
            var state = usuario.ID == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(usuario).State = state;
            context.Add(usuario);
            context.SaveChanges();
            return usuario;
        }
        public Usuario Update(Usuario usuario)
        {
            var _usuario = context.Usuarios.Where(x => x.ID == usuario.ID).FirstOrDefault();

            if (_usuario != null)
            {
                _usuario.Nome = usuario.Nome;
                _usuario.Email = usuario.Email;
                _usuario.Password = usuario.Password;

                context.Entry(_usuario).State = EntityState.Modified;
                context.SaveChanges();
            }

            return usuario;
        }
        public bool Delete(int Id)
        {
            var _usuario = context.Usuarios.Where(x => x.ID == Id).FirstOrDefault();

            if (_usuario != null)
            {
                context.Entry(_usuario).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
