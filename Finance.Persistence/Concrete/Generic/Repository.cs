﻿using Finance.Persistence.Abstract.Generic;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Concrete.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly DbSet<TEntity> _dbSet;
        private readonly FinanceDbContext _dbContext;

        public Repository(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
                _dbSet.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities.Count() > 0)
                _dbSet.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();

        }


        public Task<IQueryable<TEntity>> FindWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = _dbSet.Where(predicate);
            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }
            return Task.FromResult(queryable);
        }


        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

    }
}
