using Estudos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Api.Database
{
    // Contexto do banco de dados para a aplicação Estudos
    public class DbEstudos : DbContext
    {
        // Construtor que recebe as opções do DbContext
        public DbEstudos(DbContextOptions<DbEstudos> options) : base(options)
        {
        }

        // Conjunto de entidades para a tabela Usuarios
        public DbSet<Usuarios> Usuarios { get; set; }

        // Configuração do modelo de dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasSequence<int>("Seq_Usuarios", schema: "dbo")
                .StartsAt(1)
                .IncrementsBy(1);

            // Configuração da entidade Usuarios
            builder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("Usuarios");
                
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_Usuarios");

                entity.Property(e => e.Nome)
                .HasMaxLength(100);

                entity.Property(e => e.Email)
                .HasMaxLength(100);

                entity.Property(e => e.Senha)
                .HasMaxLength(100);

                entity.Property(e => e.DataCriacao)
                .HasMaxLength(100);
            });

        }


    }
}
