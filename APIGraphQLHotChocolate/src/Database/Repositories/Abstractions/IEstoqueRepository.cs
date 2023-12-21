using APIGraphQLHotChocolate.src.Database.Domain;

namespace APIGraphQLHotChocolate.src.Database.Repositories.Abstractions
{
    public interface IEstoqueRepository
    {
        Task AdicionarAsync(Estoque entity);
        IQueryable<Estoque> ObterAsync(Guid? id = null);
    }
}
