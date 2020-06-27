using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codenation.Dominio.Services
{
    public class ModeloService: IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        public IList<Modelo> Modelos()
        {
            try
            {
                return _modeloRepository.Get().ToList();
            }
            catch
            {
                return new List<Modelo>();
            }
        }

        public Modelo ModeloById(int ID)
        {
            return _modeloRepository.GetById(ID);
        }

    }
}
