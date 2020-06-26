namespace Codenation.Dominio.Entidades
{
    public class Carro
    {
        public int ID { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
        public int? MarcaID { get; set; }
        public Marca Marca { get; set; }
        public int? ModeloID { get; set; }
        public Modelo Modelo { get; set; }
        public int? VersaoID { get; set; }
        public Versao Versao { get; set; }
    }
}
