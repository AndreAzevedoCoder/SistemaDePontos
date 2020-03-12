using System.Collections.Generic;

namespace PontoMVC.Database
{
    public class Funcionario
    {
        public int idFuncionario {get;set;}
        public string Nome {get;set;}
        public string Login {get;set;}
        public string Senha {get;set;}
        public virtual IList<DiaDeTrabalho> ListaDiasDeTrabalho {get;set;}
    }
}