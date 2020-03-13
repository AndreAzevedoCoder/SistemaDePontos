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
    public class HomeController : AbstractController
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

    }
}
