using System.Collections.Generic;
using SistemaDePonto.Domains;

namespace PontoMVC.ViewModel
{
    public class FuncionarioViewModel
    {
        public string Nome {get;set;}
        public List<DiasDeTrabalho> DiasDeTrabalho {get;set;}

        //Caso necessite ver apenas um dia de trabalho
        public DiasDeTrabalho DiaDeTrabalho {get;set;}
        public int HorasTrabalhadasHoje {get;set;}
        public int HorasTotaisDoMes {get;set;}
    }
}