using System;
using System.Collections.Generic;

namespace SistemaDePonto.Domains
{
    public partial class DiasDeTrabalho
    {
        public DiasDeTrabalho()
        {
            Historico = new HashSet<Historico>();
        }

        public int IdDia { get; set; }
        public string EnderecoIp { get; set; }
        public int? IdFuncionario { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? IntervaloEntrada { get; set; }
        public DateTime? IntervaloSaida { get; set; }
        public DateTime? Saida { get; set; }

        public virtual Funcionarios IdFuncionarioNavigation { get; set; }
        public virtual ICollection<Historico> Historico { get; set; }
    }
}
