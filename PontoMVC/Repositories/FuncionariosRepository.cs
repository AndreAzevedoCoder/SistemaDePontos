using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDePonto.Interfaces;
using SistemaDePonto.Domains;
using SistemaDePonto.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace SistemaDePonto.Repositories
{
    public class FuncionariosRepository : IFuncionarioRepository
    {
        sistemaDePontosContext ctx = new sistemaDePontosContext();
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

        public DiasDeTrabalho ObterDiaDeTrabalho( int idDia)
        {
            return ctx.DiasDeTrabalho.Where(b => b.IdDia == idDia).FirstOrDefault();
        }

        public void atualizarDiaDeTrabalho(DiasDeTrabalho diaAtualizado){
            DiasDeTrabalho diaAntigo = ctx.DiasDeTrabalho.FirstOrDefault(p => p.IdDia == diaAtualizado.IdDia);
            Console.WriteLine(diaAntigo.IntervaloEntrada);
            if(diaAtualizado.Entrada != null){
                diaAntigo.Entrada = diaAtualizado.Entrada;
            }

            if(diaAtualizado.IntervaloEntrada != null){
                diaAntigo.IntervaloEntrada = diaAtualizado.IntervaloEntrada;
            }

            if(diaAtualizado.IntervaloSaida != null){
                diaAntigo.IntervaloSaida = diaAtualizado.IntervaloSaida;
            }

            if(diaAtualizado.Saida != null){
                diaAntigo.Saida = diaAtualizado.Saida;
            }

            ctx.SaveChanges();
        }

        public void DeletarDiaDeTrabalho(int id){
            ctx.DiasDeTrabalho.Remove(ObterDiaDeTrabalho(id));
            ctx.SaveChanges();
        }

        public void adicionarDiaDeTrabalho(int idFuncionario){
            DiasDeTrabalho diasDeTrabalho = new DiasDeTrabalho();
            diasDeTrabalho.Entrada = DateTime.Now;
            diasDeTrabalho.IdFuncionario = idFuncionario;
            ctx.DiasDeTrabalho.Add(diasDeTrabalho);
            ctx.SaveChanges();
        }

    }
}
