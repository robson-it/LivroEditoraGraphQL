using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace APIGraphQLHotChocolate.src.Database.Repositories
{
    public class EditoraRepository : IEditoraRepository
    {

        private readonly IRepositoryBase<Editora> _repositoryBase;

        public EditoraRepository(IRepositoryBase<Editora> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AdicionarAsync(Editora entity)
        {
            entity.Id = Guid.NewGuid();
            await _repositoryBase.AdicionarAsync(entity);
        }

        public IQueryable<Editora> ObterAsync(Guid? id = null)
        {
            return _repositoryBase.ObterAsync(id)
                .Include(q => q.Livros)
                .ThenInclude(z => z.Estoque);
        }


    }
}
