using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace APIGraphQLHotChocolate.src.Database.Repositories
{
    public class LivroRepository : ILivroRepository
    {

        private readonly IRepositoryBase<Livro> _repositoryBase;

        public LivroRepository(IRepositoryBase<Livro> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AdicionarAsync(Livro entity)
        {
            entity.Id = Guid.NewGuid();
            await _repositoryBase.AdicionarAsync(entity);
        }


        public IQueryable<Livro> ObterAsync(Guid? id = null)
        {
            return _repositoryBase.ObterAsync(id)
                .Include(q => q.Editora)
                .Include(z => z.Estoque);
        }


    }
}
