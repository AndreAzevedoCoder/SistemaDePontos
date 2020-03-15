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
        public int[] HorasTrabalhadas(int idFuncionario, int dia, int mes){
            int[] horasTrabalhadas = new int[2];
            List<DiasDeTrabalho> diasDeTrabalho = ctx.DiasDeTrabalho.Where(p => p.IdFuncionario == idFuncionario).ToList();
            foreach (DiasDeTrabalho diaDeTrabalho in diasDeTrabalho)
            {
                DateTime diaDeHojeEntrada = DateTime.Parse(diaDeTrabalho.Entrada.ToString());
                if(diaDeTrabalho.Saida != null){
                    DateTime diaDeHojeSaida = DateTime.Parse(diaDeTrabalho.Saida.ToString());
                    if(diaDeHojeEntrada.Day == dia){
                        horasTrabalhadas[0] += diaDeHojeSaida.Hour - diaDeHojeEntrada.Hour;
                    }
                    if(diaDeHojeEntrada.Month == mes){
                        horasTrabalhadas[1] += diaDeHojeSaida.Hour - diaDeHojeEntrada.Hour;
                    }
                }
            }
            return horasTrabalhadas;
        }

        public Funcionarios BuscarPorID(int id){
            return ctx.Funcionarios.FirstOrDefault(f => f.IdFuncionario == id);
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
            Historico historico = new Historico();
            historico.IdDia = diaAtualizado.IdDia;
            historico.IdFuncionario = diaAtualizado.IdFuncionario;
            historico.Quando = DateTime.Now;
            historico.Ocorrido = "Atualizou: ";

            if(diaAtualizado.Entrada != null && diaAtualizado.Entrada != diaAntigo.Entrada){
                diaAntigo.Entrada = diaAtualizado.Entrada;
                historico.Ocorrido += "ENTRADA ";
            }

            if(diaAtualizado.IntervaloEntrada != null && diaAtualizado.IntervaloEntrada != diaAntigo.IntervaloEntrada){
                diaAntigo.IntervaloEntrada = diaAtualizado.IntervaloEntrada;
                historico.Ocorrido += "Intervalo da Entrada ";
            }

            if(diaAtualizado.IntervaloSaida != null && diaAtualizado.IntervaloSaida != diaAntigo.IntervaloSaida){
                diaAntigo.IntervaloSaida = diaAtualizado.IntervaloSaida;
                historico.Ocorrido += "Intervalo da Saida ";
            }

            if(diaAtualizado.Saida != null && diaAtualizado.Saida != diaAntigo.Saida){
                diaAntigo.Saida = diaAtualizado.Saida;
                historico.Ocorrido += "Saida ";
            }

            ctx.Historico.Add(historico);
            ctx.SaveChanges();
        }

            // historico.IdDia = idDia;
            // historico.IdFuncionario = diaDeletado.IdFuncionario;
            // historico.Quando = DateTime.Now;
            // historico.Ocorrido = "Deletou";
            // ctx.Historico.Add(historico);
        public void DeletarDiaDeTrabalho(int idDia){
            //Historico historico = new Historico();
            DiasDeTrabalho diaDeletado = ObterDiaDeTrabalho(idDia);
            diaDeletado.IdFuncionario = null;
            ctx.SaveChanges();
            ctx.DiasDeTrabalho.Remove(diaDeletado);

            

            ctx.SaveChanges();
        }

        public void adicionarDiaDeTrabalho(int idFuncionario, string ip){
            DiasDeTrabalho diasDeTrabalho = new DiasDeTrabalho();
            diasDeTrabalho.Entrada = DateTime.Now;
            diasDeTrabalho.EnderecoIp = ip;
            diasDeTrabalho.IdFuncionario = idFuncionario;
            ctx.DiasDeTrabalho.Add(diasDeTrabalho);
            ctx.SaveChanges();
        }

    }
}
