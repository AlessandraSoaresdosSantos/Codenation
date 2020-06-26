using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Entidades
{
    public class Versao
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int ModeloID { get; set; }
        public Modelo Modelo { get; set; }
    }
}
