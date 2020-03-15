using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaDePonto.Models;
using SistemaDePonto.Interfaces;
using SistemaDePonto.Repositories;
using PontoMVC.Controllers;
using Microsoft.AspNetCore.Http;

namespace SistemaDePonto.Controllers
{
    public class HomeController : AbstractController
    {
        FuncionariosRepository _funcionarioRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _funcionarioRepository = new FuncionariosRepository();
        }

        public IActionResult Index()
        {
            switch(ObterUsuarioEmailSession()){
                case "":
                    return View();
                default:
                    return RedirectToAction("Dashboard","Funcionario");
            }
        }
        public IActionResult Cadastro(){
            switch(ObterUsuarioEmailSession()){
                case "":
                    return View();
                default:
                    return RedirectToAction("Dashboard","Funcionario");
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form){
            if(form["Senha"] == form["SenhaNovamente"]){

                int id = _funcionarioRepository.Cadastrar(form["Nome"],form["Email"],form["Senha"]);

                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, form["Email"]);
                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, form["Nome"]);
                HttpContext.Session.SetString(SESSION_CLIENTE_ID, id.ToString());
                return RedirectToAction("Dashboard","Funcionario");
            }
            return View("Cadastro");

        }

    }
}
