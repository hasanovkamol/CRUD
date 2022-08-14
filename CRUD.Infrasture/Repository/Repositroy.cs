using Common.Utils.Model;
using CRUD.Application.Presistencs;
using CRUD.Infrasture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRUD.Infrasture.Repository
{
    public class Repositroy<T> : IRepository<T> where T : EntityBase
    {
        private readonly CustomDbContext _dbContext;
        public Repositroy(CustomDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TKey> AddAsync<TKey>(TKey entity) where TKey : EntityBase
        {
            _dbContext.Set<TKey>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void Attach(T Tentity)
            => _dbContext.Attach(Tentity);

        public void AttachRange(IEnumerable<T> Tentitys)
            => _dbContext.AttachRange(Tentitys);

        public async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<TKey>(TKey entity) where TKey : EntityBase
        {
            _dbContext.Set<TKey>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteHeddinAsync<TKey>(TKey entity) where TKey : EntityBase
        {
            entity.Hidden();
            _dbContext.Set<TKey>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteHiddenAsync(T entity)
        {
            entity.Hidden();
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public void DetachAsync(T entity)
            => _dbContext.Entry(entity).State = EntityState.Detached;

        public async Task<T> FindAsync(int id)
            => await _dbContext.Set<T>().FindAsync(id);

        public async Task<TKey> FindAsync<TKey>(int id) where TKey : EntityBase
            => await _dbContext.Set<TKey>().FindAsync(id);


        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string includString = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (!string.IsNullOrWhiteSpace(includString))
            {
                foreach (var item in includString.Split(";"))
                {
                    query = query.Include(item);
                }
            };

            if (predicate != null) query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TKey> GetFirstOrDefaultAsync<TKey>(Expression<Func<TKey, bool>> predicate, string includString = null) where TKey : EntityBase
        {
            IQueryable<TKey> query = _dbContext.Set<TKey>();

            if (!string.IsNullOrWhiteSpace(includString))
            {
                foreach (var item in includString.Split(";"))
                {
                    query = query.Include(item);
                }
            };

            if (predicate != null) query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString))
            {
                foreach (var item in includeString.Split(";"))
                {
                    query = query.Include(item);
                }
            };

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query);
            return query;
        }

        public IQueryable<T> GetQueryableAsync(Expression<Func<T, bool>> predicate)
            => _dbContext.Set<T>().Where(predicate).AsQueryable();

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateRange(IEnumerable<T> entitys)
        {
            _dbContext.Set<T>().UpdateRange(entitys);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync<TKey>(TKey entity) where TKey : EntityBase
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
