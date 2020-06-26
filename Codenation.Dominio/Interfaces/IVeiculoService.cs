using Codenation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Interfaces
{
    public interface IVeiculoService
    {
        IList<Veiculo> Veiculos();
        Veiculo VeiculoById(int ID);


    }
}
