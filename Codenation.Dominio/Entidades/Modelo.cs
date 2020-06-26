using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Entidades
{
   public class Modelo
    {
        public int ID { get; set; }
        public string  Nome { get; set; }
        public int MarcaID { get; set; }
        public Marca Marca { get; set; }
    }
}
