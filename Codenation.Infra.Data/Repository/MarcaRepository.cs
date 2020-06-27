using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using Codenation.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Infra.Data.Repository
{
   public class MarcaRepository: IMarcaRepository
    {

        private readonly DataContext context;
        public MarcaRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Marca> Get()
        {
            return context.Marcas;
        }
        public Marca GetById(int Id)
        {
            return context.Marcas.Where(x => x.ID == Id).FirstOrDefault();
        }
        public Marca Save(Marca marca)
        {
            var state = marca.ID == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(marca).State = state;
            context.Add(marca);
            context.SaveChanges();
            return marca;
        }
        public Marca Update(Marca marca)
        {
            var _marca = context.Marcas.Where(x => x.ID == marca.ID).FirstOrDefault();

            if (_marca != null)
            {
                _marca.Nome = marca.Nome;
               
                context.Entry(_marca).State = EntityState.Modified;
                context.SaveChanges();
            }

            return marca;
        }
        public bool Delete(int Id)
        {
            var _marca = context.Marcas.Where(x => x.ID == Id).FirstOrDefault();

            if (_marca != null)
            {
                context.Entry(_marca).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
