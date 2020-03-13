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
using PontoMVC.ViewModel;
using Microsoft.AspNetCore.Http;
using SistemaDePonto.Domain;

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
                    return RedirectToAction("Index","Home");
                default:
                    FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel{
                        Nome = ObterUsuarioNomeSession(),
                        DiasDeTrabalho = _funcionarioRepository.ObterDiasDeTrabalho(Int32.Parse(ObterIDUsuarioSession()))
                    };
                    return View("Dashboard",funcionarioViewModel);
            }
        }

        [HttpPost]
        public IActionResult EditorDeDiaDeTrabalho(IFormCollection form){

            DiasDeTrabalho dia = _funcionarioRepository.ObterDiaDeTrabalho(Int32.Parse(ObterIDUsuarioSession()), Int32.Parse(form["idDia"]));
            DiaDeTrabalhoViewModel diaDeTrabalhoViewModel = new DiaDeTrabalhoViewModel{
                Entrada = DateTime.Parse(dia.Entrada.ToString()),
                //IntervaloEntrada = DateTime.Parse(dia.IntervaloEntrada.ToString()),
                //IntervaloSaida = DateTime.Parse(dia.IntervaloSaida.ToString()),
                Saida = DateTime.Parse(dia.Saida.ToString())
            };
            
            return View("EditorDeDiaDeTrabalho",diaDeTrabalhoViewModel);
        }

    }
}
