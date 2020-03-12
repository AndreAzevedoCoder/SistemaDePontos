using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDePonto.Domain
{
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            DiasDeTrabalho = new HashSet<DiasDeTrabalho>();
        }

        public int IdFuncionario { get; set; }
        
        [DataType("varchar2")]
        public string Nome { get; set; }
        [DataType("varchar2")]
        public string email { get; set; }
        [DataType("varchar2")]
        public string Senha { get; set; }

        public virtual ICollection<DiasDeTrabalho> DiasDeTrabalho { get; set; }
    }
}
