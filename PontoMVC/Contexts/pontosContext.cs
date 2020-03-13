using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaDePonto.Domain;

namespace SistemaDePonto.Contexts
{
    public partial class pontosContext : DbContext
    {
        public pontosContext()
        {
        }

        public pontosContext(DbContextOptions<pontosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiasDeTrabalho> DiasDeTrabalho { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=sistemaDePontos; user Id=SA; pwd=database@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiasDeTrabalho>(entity =>
            {
                entity.HasKey(e => e.IdDia)
                    .HasName("PK__diasDeTr__3E416597EAC6285D");

                entity.ToTable("diasDeTrabalho");

                entity.Property(e => e.IdDia).HasColumnName("idDia");

                entity.Property(e => e.EnderecoIp)
                    .HasColumnName("enderecoIP")
                    .HasColumnType("text");

                entity.Property(e => e.Entrada).HasColumnName("entrada");

                entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");

                entity.Property(e => e.IntervaloEntrada).HasColumnName("intervaloEntrada");

                entity.Property(e => e.IntervaloSaida).HasColumnName("intervaloSaida");

                entity.Property(e => e.Saida).HasColumnName("saida");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.DiasDeTrabalho)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK__diasDeTra__idFun__4E88ABD4");
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PK__funciona__B0A1229569386B6A");

                entity.ToTable("funcionarios");

                entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");

                entity.Property(e => e.email)
                    .HasColumnName("email")
                    .HasColumnType("nvarchar(255)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("nvarchar(255)");

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasColumnType("nvarchar(255)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
