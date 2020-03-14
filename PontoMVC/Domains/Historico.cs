using System;
using System.Collections.Generic;

namespace SistemaDePonto.Domains
{
    public partial class Historico
    {
        public int IdHistorico { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdDia { get; set; }
        public string Ocorrido { get; set; }
        public DateTime Quando { get; set; }

        public virtual DiasDeTrabalho IdDiaNavigation { get; set; }
        public virtual Funcionarios IdFuncionarioNavigation { get; set; }
    }
}
