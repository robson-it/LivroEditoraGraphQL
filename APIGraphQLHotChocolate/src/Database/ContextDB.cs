using APIGraphQLHotChocolate.src.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace APIGraphQLHotChocolate.src.Database
{
    public class ContextDB : DbContext
    {

        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("TB_LIVRO");
            modelBuilder.Entity<Editora>().ToTable("TB_EDITORA");
            modelBuilder.Entity<Estoque>().ToTable("TB_ESTOQUE");

            _ = modelBuilder.Entity<Livro>()
                .HasOne(_ => _.Editora)
                .WithMany(t => t.Livros)
                .HasForeignKey("EditoraId")
                .OnDelete(DeleteBehavior.Cascade);

            _ = modelBuilder.Entity<Estoque>()
                .HasOne(_ => _.Livro)
                .WithOne(t => t.Estoque)
                .HasForeignKey<Estoque>("LivroId")
                .OnDelete(DeleteBehavior.Cascade);

          
        }

    }
}
