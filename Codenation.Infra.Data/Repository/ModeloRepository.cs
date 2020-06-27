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
    public class ModeloRepository: IModeloRepository
    {
        private readonly DataContext context;
        public ModeloRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Modelo> Get()
        {
            return context.Modelos;
        }
        public Modelo GetById(int Id)
        {
            return context.Modelos.Where(x => x.ID == Id).FirstOrDefault();
        }
        public Modelo Save(Modelo modelo)
        {
            var state = modelo.ID == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(modelo).State = state;
            context.Add(modelo);
            context.SaveChanges();
            return modelo;
        }
        public Modelo Update(Modelo modelo)
        {
            var _modelo = context.Modelos.Where(x => x.ID == modelo.ID).FirstOrDefault();

            if (_modelo != null)
            {
                _modelo.Nome = modelo.Nome;
                _modelo.MarcaID = modelo.MarcaID;

                context.Entry(_modelo).State = EntityState.Modified;
                context.SaveChanges();
            }

            return modelo;
        }
        public bool Delete(int Id)
        {
            var _modelo = context.Modelos.Where(x => x.ID == Id).FirstOrDefault();

            if (_modelo != null)
            {
                context.Entry(_modelo).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
