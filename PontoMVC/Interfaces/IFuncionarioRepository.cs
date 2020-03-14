using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDePonto.Domains;
namespace SistemaDePonto.Interfaces
{
    interface IFuncionarioRepository
    {
        List<Funcionarios> Listar();
        Funcionarios BuscarPorID(int id);
        void Cadastrar(Funcionarios funcionario);
        Funcionarios Login(string email, string senha);
        List<DiasDeTrabalho> ObterDiasDeTrabalho(int idFuncionario);
        DiasDeTrabalho ObterDiaDeTrabalho(int idDia);
        void atualizarDiaDeTrabalho(DiasDeTrabalho diaAtualizado);
        void DeletarDiaDeTrabalho(int id);
        void adicionarDiaDeTrabalho(int idFuncionario);
        
    }
}
