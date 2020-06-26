using Codenation.Dominio.Entidades;
using Codenation.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Codenation.Dominio.Services
{
    public class VeiculosService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculosService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public IList<Veiculo> Veiculos()
        {
            try
            {
                return _veiculoRepository.Get().ToList();
            }
            catch
            {
                return new List<Veiculo>();
            }
        }

        public Veiculo VeiculoById(int ID)
        {
            return _veiculoRepository.GetById(ID);
        }

    }
}
