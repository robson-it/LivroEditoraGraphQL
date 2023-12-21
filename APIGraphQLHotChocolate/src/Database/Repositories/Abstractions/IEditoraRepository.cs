using APIGraphQLHotChocolate.src.Database.Domain;

namespace APIGraphQLHotChocolate.src.Database.Repositories.Abstractions
{
    public interface IEditoraRepository
    {
        Task AdicionarAsync(Editora entity);
        IQueryable<Editora> ObterAsync(Guid? id = null);
    }
}
