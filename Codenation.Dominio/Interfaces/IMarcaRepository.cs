using Codenation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Interfaces
{
  public  interface IMarcaRepository
    {
        IEnumerable<Marca> Get();
        Marca GetById(int Id);
        Marca Save(Marca veiculo);
        Marca Update(Marca veiculo);
        bool Delete(int Id);
    }
}
