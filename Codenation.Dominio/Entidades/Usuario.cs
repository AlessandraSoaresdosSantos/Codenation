using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Dominio.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
