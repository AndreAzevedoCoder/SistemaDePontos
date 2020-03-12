using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

using PontoMVC.Database.Interfaces;

namespace PontoMVC.Database.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        PontoContext ctx = new PontoContext("Server=localhost;Database=SistemaDePontos;User Id=Satva;Password=database@132;");
        public void Cadastrar(Funcionario funcionario)
        {

            ctx.Funcionarios.Add(funcionario);
            ctx.SaveChanges();
            
        }

        public void Logar(Funcionario funcionario)
        {
            throw new System.NotImplementedException();
        }
    }
}