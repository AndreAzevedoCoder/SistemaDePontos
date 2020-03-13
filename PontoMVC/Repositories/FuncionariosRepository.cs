﻿using System;
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
        /// <summary>
        /// Busca um usuario por email e senha 
        /// </summary>
        /// <param name="email">email do usuário que será buscado</param>
        /// <param name="senha">senha do usuário que será buscado</param>
        /// <returns>Um usuário com os parametros correspondentes</returns>

        public Funcionarios Login(string email, string senha)
        {
            return ctx.Funcionarios.Where(b => b.Email == email && b.Senha == senha).FirstOrDefault();;
        }

        public List<DiasDeTrabalho> ObterDiasDeTrabalho(int idFuncionario)
        {
            return ctx.DiasDeTrabalho.Where(b => b.IdFuncionario == idFuncionario).ToList();
        }

        public DiasDeTrabalho ObterDiaDeTrabalho(int idFuncionario, int idDia)
        {
            return ctx.DiasDeTrabalho.Where(b => b.IdFuncionario == idFuncionario && b.IdDia == idDia).FirstOrDefault();
        }
    }
}
