using Codenation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Interfaces
{
   public interface IMarcaService
    {
        IList<Marca> Marcas();
        Marca MarcaById(int ID);
        Marca Salvar(Marca marca);
        Marca Atualizar(Marca marca);
        bool Deletar(int ID);
    }
}
