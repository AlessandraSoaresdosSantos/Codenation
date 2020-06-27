using Codenation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Interfaces
{
    public interface IModeloService
    {
        IList<Modelo> Modelos();
        Modelo ModeloById(int ID);
    }
}
