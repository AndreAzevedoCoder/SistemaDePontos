using System;
using System.Collections.Generic;

namespace SistemaDePonto.Domain
{
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            DiasDeTrabalho = new HashSet<DiasDeTrabalho>();
        }

        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Nickname { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<DiasDeTrabalho> DiasDeTrabalho { get; set; }
    }
}
