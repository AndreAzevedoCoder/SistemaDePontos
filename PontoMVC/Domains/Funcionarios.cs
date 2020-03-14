using System;
using System.Collections.Generic;

namespace SistemaDePonto.Domains
{
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            DiasDeTrabalho = new HashSet<DiasDeTrabalho>();
            Historico = new HashSet<Historico>();
        }

        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DiasDeTrabalho> DiasDeTrabalho { get; set; }
        public virtual ICollection<Historico> Historico { get; set; }
    }
}
