using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDePonto.Interfaces;
using SistemaDePonto.Domain;
using SistemaDePonto.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace SistemaDePonto.Repositories
{
    public class FuncionariosRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source=localhost; Initial Catalog=sistemaDePontos; user Id=SA; pwd=database@132;";
        pontosContext ctx = new pontosContext();
        public List<Funcionarios> Listar(){
            return ctx.Funcionarios.ToList();
        }
        public Funcionarios BuscarPorID(int id){
            return ctx.Funcionarios.FirstOrDefault(f => f.IdFuncionario == id);
        }
        public void Cadastrar(Funcionarios funcionario)
        {
            
        }
        public void Login(Funcionarios funcionario)
        {

        }
        /// <summary>
        /// Busca um usuario por email e senha
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado e um status code 200 - Ok</returns>

        
        public Funcionarios BuscarPorEmailESenha(string email, string senha)
        {
            Funcionarios funcionario = ctx.Funcionarios.Where(b => b.email ==   email.ToString()).FirstOrDefault();
            return funcionario;


            // List<Funcionarios> listaDeFuncionarios = Listar();
            // foreach(Funcionarios Funcionario in listaDeFuncionarios){
            //     if(Funcionario.email == email && Funcionario.Senha == senha){
            //         funcionario = Funcionario;
            //         return Funcionario;
            //     }
            // }

        }
    }
}
