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
    public class UsuarioController: Controller
    {
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
	    public IActionResult Login(Usuario userForm){		
    		UsuarioRepository ur = new UsuarioRepository();
		    Usuario userEncontrado =  ur.ValidarLogin(userForm);
		    if(userEncontrado == null){
    			ViewBag.Mensagem = "Falha no login!";
	    		return View();
		    }else{
				HttpContext.Session.SetInt32("IdUsuario", userEncontrado.Id);
				HttpContext.Session.SetString("NomeUsuario", userEncontrado.Nome);
			    return RedirectToAction("Listagem", "Usuario");
		    }
	    }

		public IActionResult Logout(){
			HttpContext.Session.Clear();
			return RedirectToAction("Login", "Usuario");
	    }

        public IActionResult Cadastro(){
            return View();
        }

	    [HttpPost] //protocolo de segurança
	    public IActionResult Cadastro(Usuario userForm){	
    		UsuarioRepository ur = new UsuarioRepository();
		    ur.Cadastrar(userForm);
		    return RedirectToAction("Listagem", "Usuario");
	    }

	    public IActionResult Editar(int Id){				
			if(HttpContext.Session.GetInt32("IdUsuario")==null){
				return RedirectToAction("Login", "Usuario");
			}
    		UsuarioRepository ur = new UsuarioRepository();
		    Usuario userEncontrado = ur.BuscarPorId(Id);
		    return View(userEncontrado);
	    }

	    [HttpPost]
	    public IActionResult Editar(Usuario userForm){		
    		UsuarioRepository ur = new UsuarioRepository();
		    ur.Editar(userForm);
		    return RedirectToAction("Listagem", "Usuario");
	    }
	
	    public IActionResult Excluir(int Id){				
			if(HttpContext.Session.GetInt32("IdUsuario")==null){
				return RedirectToAction("Login", "Usuario");
			}
		    UsuarioRepository ur = new UsuarioRepository();
		    Usuario userEncontrado = ur.BuscarPorId(Id);
		    ur.Excluir(userEncontrado);
		    return RedirectToAction("Listagem", "Usuario");
	    }	

	    public IActionResult Listagem(){	
			if(HttpContext.Session.GetInt32("IdUsuario")==null){
				return RedirectToAction("Login", "Usuario");
			}
    		UsuarioRepository ur = new UsuarioRepository();
		    List<Usuario> Lista =  ur.Listar();
		    return View(Lista);
	    }

    }
}