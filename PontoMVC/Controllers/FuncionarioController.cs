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

namespace SistemaDePonto.Controllers
{
    public class FuncionarioController : AbstractController
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        private readonly ILogger<HomeController> _logger;

        public FuncionarioController(ILogger<HomeController> logger)
        {
            _funcionarioRepository = new FuncionariosRepository();
            _logger = logger;
        }

        public IActionResult Dashboard()
        {
            switch(ObterUsuarioEmailSession()){
                case "":
                    return View("erro");
                default:
                    return View();
            }
        }

    }
}
