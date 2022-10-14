using System;
using System.Collections.Generic;

namespace PIE4_VanessaCampos.Models
{
    public class Carrinho
    {
        public int Id {get; set;}        
        public int Usuario {get; set;}
        public string Produto {get; set;}        
        public int Quantidade {get; set;}
    }
}