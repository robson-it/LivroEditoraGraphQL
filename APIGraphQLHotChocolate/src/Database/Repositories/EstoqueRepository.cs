using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace APIGraphQLHotChocolate.src.Database.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {

        private readonly IRepositoryBase<Estoque> _repositoryBase;

        public EstoqueRepository(IRepositoryBase<Estoque> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AdicionarAsync(Estoque entity)
        {
            entity.Id = Guid.NewGuid();
            await _repositoryBase.AdicionarAsync(entity);
        }


        public IQueryable<Estoque> ObterAsync(Guid? id = null)
        {
            return _repositoryBase.ObterAsync(id)
                .Include(q => q.Livro)
                .ThenInclude(z => z.Editora);
        }

    }
}
