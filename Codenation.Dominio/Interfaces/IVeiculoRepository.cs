using Codenation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Interfaces
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> Get();
        Veiculo GetById(int Id);
        Veiculo Save(Veiculo veiculo);
        Veiculo Update(Veiculo veiculo);
        bool Delete(int Id);
    }
}
