using System.Linq.Expressions;
using APIGraphQLHotChocolate.src.Database.Domain.Models;

namespace APIGraphQLHotChocolate.src.Database.Repositories.Abstractions
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> ObterAsync(Guid? id = null);
        Task AdicionarAsync(TEntity entity);

    }
}
