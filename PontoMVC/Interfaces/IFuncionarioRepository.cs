using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDePonto.Domain;
namespace SistemaDePonto.Interfaces
{
    interface IFuncionarioRepository
    {
        public List<Funcionarios> Listar();
        public Funcionarios BuscarPorID(int id);
        public void Cadastrar(Funcionarios funcionario);
        public void Login(Funcionarios funcionario);
    }
}
