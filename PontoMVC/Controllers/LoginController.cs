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
using Microsoft.AspNetCore.Http;
using PontoMVC.Controllers;
using SistemaDePonto.Domains;

namespace SistemaDePonto.Controllers
{
    public class LoginController : AbstractController
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }
        private readonly ILogger<HomeController> _logger;
        public LoginController(ILogger<HomeController> logger)
        {
            _funcionarioRepository = new FuncionariosRepository();
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Logar(IFormCollection form)
        {
            
            string email = form["Email"];
            string senha = form["Senha"];
            if(email != "" && senha != "" ){
                
                Funcionarios funcionario = _funcionarioRepository.Login(email,senha);
                if(!String.IsNullOrEmpty(funcionario.Nome)){
                    HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, email);
                    HttpContext.Session.SetString(SESSION_CLIENTE_NOME, funcionario.Nome);
                    HttpContext.Session.SetString(SESSION_CLIENTE_ID, funcionario.IdFuncionario.ToString());
                    return RedirectToAction("Dashboard","Funcionario");
                }

            }
            return View("Index");
        }
    }
}
