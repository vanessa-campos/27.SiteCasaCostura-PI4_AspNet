using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PIE4_VanessaCampos.Models;

namespace PIE4_VanessaCampos.Controllers
{
    public class CarrinhoController: Controller
    {
        public IActionResult Carrinho(){
            if(HttpContext.Session.GetInt32("IdUsuario")==null){
				    return RedirectToAction("Login", "Usuario");
				}
			int Id = Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));
    		CarrinhoRepository cr = new CarrinhoRepository();
			Carrinho carrinho = cr.BuscarCarrinho(Id);
		    List<Carrinho> Lista = cr.Listar();
		    return View(Lista);
        }
   	
		public IActionResult Adicionar(string Produto){            
           if(HttpContext.Session.GetInt32("IdUsuario")==null){
				    return RedirectToAction("Login", "Usuario");
				}
		 	CarrinhoRepository cr = new CarrinhoRepository();
			Carrinho carrinho = new Carrinho();
			carrinho.Usuario = Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));
			carrinho.Produto = Produto;
			carrinho.Quantidade = 1;
            cr.Adicionar(carrinho);
            return RedirectToAction("Carrinho");
        }		

        public IActionResult Excluir(int Id){				
			if(HttpContext.Session.GetInt32("IdUsuario")==null){
				return RedirectToAction("Login", "Usuario");
			}
		    CarrinhoRepository cr = new CarrinhoRepository();
		    Carrinho carrinhoEncontrado = cr.BuscarPorId(Id);
		    cr.Excluir(carrinhoEncontrado);
		    return RedirectToAction("Carrinho");
	    }	

        public IActionResult Produtos(){
    		CarrinhoRepository cr = new CarrinhoRepository();
		    List<Produto> Lista = cr.ListarProdutos();
		    return View(Lista);
        }	

        public IActionResult Exclusivos(){			
    		CarrinhoRepository cr = new CarrinhoRepository();
		    List<Produto> Lista = cr.ListarProdutos();
            return View(Lista);
        }
		
    }
}
