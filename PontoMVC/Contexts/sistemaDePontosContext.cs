using System;
using Microsoft.EntityFrameworkCore;
using SistemaDePonto.Domains;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaDePonto.Contexts
{
    public partial class sistemaDePontosContext : DbContext
    {
        public sistemaDePontosContext()
        {
        }

        public sistemaDePontosContext(DbContextOptions<sistemaDePontosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiasDeTrabalho> DiasDeTrabalho { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;User Id=SA;Password=database@132;Database=sistemaDePontos;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiasDeTrabalho>(entity =>
            {
                entity.HasKey(e => e.IdDia)
                    .HasName("PK__diasDeTr__3E4165974A833E60");

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
                    .HasConstraintName("FK__diasDeTra__idFun__38996AB5");
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PK__funciona__B0A1229532BCB9B7");

                entity.ToTable("funcionarios");

                entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => e.IdHistorico)
                    .HasName("PK__historic__4712CB7274737CE8");

                entity.ToTable("historico");

                entity.Property(e => e.IdHistorico).HasColumnName("idHistorico");

                entity.Property(e => e.IdDia).HasColumnName("idDia");

                entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");

                entity.Property(e => e.Ocorrido)
                    .IsRequired()
                    .HasColumnName("ocorrido")
                    .HasMaxLength(255);

                entity.Property(e => e.Quando).HasColumnName("quando");

                entity.HasOne(d => d.IdDiaNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.IdDia)
                    .HasConstraintName("FK__historico__idDia__4CA06362");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK__historico__idFun__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
