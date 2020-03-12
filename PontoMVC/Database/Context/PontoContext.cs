using Microsoft.EntityFrameworkCore;

namespace PontoMVC.Database
{
    public class PontoContext : DbContext
    {
        string _connectionString;
        public PontoContext(string connectionString)
        {
            this._connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._connectionString);
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<DiaDeTrabalho> DiasDeTrabalho { get; set; }
    }
}