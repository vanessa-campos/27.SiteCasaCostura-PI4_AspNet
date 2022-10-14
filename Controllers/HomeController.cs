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
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return View();
        }

        public IActionResult Servicos(){
            return View();
        }

        public IActionResult Contato(){
            return View();
        }

        public IActionResult Solicitar(Atendimento atendimento){            
            AtendimentoRepository ar = new AtendimentoRepository();
            ar.Solicitar(atendimento);
            return RedirectToAction("Atendimento");
        }

        public IActionResult Atendimento(){ 
            AtendimentoRepository ar = new AtendimentoRepository();
            List<Atendimento> Lista = ar.Listar(); 
            return View(Lista);
        }

        public IActionResult Excluir(int Id){  
		    AtendimentoRepository ar = new AtendimentoRepository();
		    Atendimento atendimento = ar.BuscarPorId(Id);
		    ar.Excluir(atendimento);
            return RedirectToAction("Atendimento");
        }
    }
}
