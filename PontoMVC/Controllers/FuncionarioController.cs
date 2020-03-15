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
using SistemaDePonto.Domains;

namespace SistemaDePonto.Controllers
{
    public class FuncionarioController : AbstractController
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        private readonly ILogger<HomeController> _logger;

        public FuncionarioController(ILogger<HomeController> logger )
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
                    int[] HorasTrabalhadas = _funcionarioRepository.HorasTrabalhadas(Int32.Parse(ObterIDUsuarioSession()),DateTime.Today.Day,DateTime.Today.Month);
                    FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel{
                        Nome = ObterUsuarioNomeSession(),
                        DiasDeTrabalho = _funcionarioRepository.ObterDiasDeTrabalho(Int32.Parse(ObterIDUsuarioSession())),
                        HorasTrabalhadasHoje = HorasTrabalhadas[0],
                        HorasTotaisDoMes = HorasTrabalhadas[1]
                    };
                   
                    return View("Dashboard",funcionarioViewModel);
            }
        }

        [HttpPost]
        public IActionResult EditorDeDiaDeTrabalho(IFormCollection form){

            DiasDeTrabalho dia = _funcionarioRepository.ObterDiaDeTrabalho(Int32.Parse(form["idDia"]));
            DiaDeTrabalhoViewModel diaDeTrabalhoViewModel = new DiaDeTrabalhoViewModel();

            
            diaDeTrabalhoViewModel.IdDia = dia.IdDia;
            
            if(dia.Entrada.ToString() != ""){
                diaDeTrabalhoViewModel.Entrada = DateTime.Parse(dia.Entrada.ToString());
            }

            if(dia.IntervaloEntrada.ToString() != ""){
                diaDeTrabalhoViewModel.IntervaloEntrada = DateTime.Parse(dia.IntervaloEntrada.ToString());
            }

            if(dia.IntervaloSaida.ToString() != ""){
                diaDeTrabalhoViewModel.IntervaloSaida = DateTime.Parse(dia.IntervaloSaida.ToString());
            }

            if(dia.Saida.ToString() != ""){
                diaDeTrabalhoViewModel.Saida = DateTime.Parse(dia.Saida.ToString());
            }        
            
            return View("EditorDeDiaDeTrabalho",diaDeTrabalhoViewModel);
        }

        
        [HttpPost]

        public IActionResult DeletarDiaDeTrabalho(IFormCollection form){
            _funcionarioRepository.DeletarDiaDeTrabalho(Int32.Parse(form["idDia"].ToString()));
            return Dashboard();
        }

        [HttpPost]
        public IActionResult EditarDiaDeTrabalho(IFormCollection form){


            DiasDeTrabalho diaModificado = new DiasDeTrabalho();

            diaModificado.IdDia = Int32.Parse(form["ID"].ToString());
            diaModificado.Entrada = dateTimeParse(form["Entrada"]);
            diaModificado.IntervaloEntrada = dateTimeParse(form["IntervaloEntrada"]);
            diaModificado.IntervaloSaida = dateTimeParse(form["IntervaloSaida"]);
            diaModificado.Saida = dateTimeParse(form["Saida"]);
            
            _funcionarioRepository.atualizarDiaDeTrabalho(diaModificado);
            return Dashboard();
        }

        [HttpPost]
        public IActionResult AdicionarDiaDeTrabalho(){

            //HttpContext.Connection.RemoteIpAddress.ToString();
            _funcionarioRepository.adicionarDiaDeTrabalho(Int32.Parse(ObterIDUsuarioSession()), HttpContext.Connection.RemoteIpAddress.ToString());
            
            return Dashboard();
        }

        DateTime dateTimeParse(string dateTimeLocal){
            if(dateTimeLocal.Length > 13 && dateTimeLocal != "1-01-01T00:00" ){
                int ano = Int32.Parse(dateTimeLocal.Substring(0,4));

                int mes = Int32.Parse(dateTimeLocal.Substring(5,2));

                int dia = Int32.Parse(dateTimeLocal.Substring(8,2));

                int hora = Int32.Parse(dateTimeLocal.Substring(11,2));

                int minuto = Int32.Parse(dateTimeLocal.Substring(14,2));

                DateTime date = new DateTime(ano, mes, dia, hora, minuto, 0);
                return date;
            }else{
                return new DateTime();
            }
        }
    }
}
