using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Codenation.Dominio.Entidades
{
    public class Veiculo
    {
        public int ID { get; set; }
        public string Imagem { get; set; }
        public int Quilometragem { get; set; }
        public double Preco { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string Cor { get; set; }

        public int? MarcaID { get; set; }
        public Marca Marca { get; set; }


        public int? ModeloID { get; set; }
        public Modelo Modelo { get; set; }


        public int? VersaoID { get; set; }
        public Versao Versao { get; set; }
    }
}
