using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Domain.Models;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APIGraphQLHotChocolate.src.Database.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : IEntity
    {

        public readonly DbSet<TEntity> _DbSet;
        public readonly ContextDB _ContextDB;

        public RepositoryBase(ContextDB contextDB)
        {
            _DbSet = contextDB.Set<TEntity>();
            _ContextDB = contextDB;
        }

        public IQueryable<TEntity> ObterAsync(Guid? id = null)
        {
            if (!id.HasValue)
            {
                return _DbSet.AsQueryable();
            }
            else
            {
                return _DbSet.Where(x => x.Id == id).AsQueryable();
            }


        }

        public async Task AdicionarAsync(TEntity entity)
        {
            await _DbSet.AddAsync(entity);
            await _ContextDB.SaveChangesAsync();
        }

    }
}
