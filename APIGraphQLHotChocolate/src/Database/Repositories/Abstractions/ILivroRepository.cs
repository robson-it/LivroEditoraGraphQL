using APIGraphQLHotChocolate.src.Database.Domain;

namespace APIGraphQLHotChocolate.src.Database.Repositories.Abstractions
{
    public interface ILivroRepository
    {
        Task AdicionarAsync(Livro entity);
        IQueryable<Livro> ObterAsync(Guid? id = null);
    }
}
