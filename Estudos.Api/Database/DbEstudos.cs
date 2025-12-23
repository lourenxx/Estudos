using Estudos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Api.Database
{
    public class DbEstudos : DbContext
    {
        public DbEstudos(DbContextOptions<DbEstudos> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasSequence<int>("Seq_Usuarios", schema: "dbo")
                .StartsAt(1)
                .IncrementsBy(1);

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
