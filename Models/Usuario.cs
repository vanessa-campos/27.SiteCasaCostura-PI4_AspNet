using System;
using System.Collections.Generic;

namespace PIE4_VanessaCampos.Models
{
    public class Usuario
    {        
        public int Id {get; set;}  
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Senha {get; set;}
        public DateTime DataNascimento {get; set;}
        public string Telefone {get; set;}
        public string Cep {get; set;}
        public string Endereco {get; set;}
    }
}