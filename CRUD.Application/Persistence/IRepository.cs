using Common.Utils.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRUD.Application.Presistencs
{
    public interface IRepository<T> where T: EntityBase
    {
        IQueryable<T> GetQueryableAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable(Expression<Func<T,
            bool>> predicate = null, 
            Func<IQueryable<T>, 
            IOrderedQueryable<T>> orderBy = null, 
            string includeString = null,
            bool disableTracking = true);
       
        Task<T> FindAsync(int id);
        Task<T> AddAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteHiddenAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> UpdateRange(IEnumerable<T> entitys);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string includString = null);
        
        Task<TKey> FindAsync<TKey>(int id) where TKey:EntityBase;
        Task<TKey> AddAsync<TKey>(TKey entity) where TKey:EntityBase;
        Task<int> DeleteAsync<TKey>(TKey entity) where TKey : EntityBase;
        Task<int> DeleteHeddinAsync<TKey>(TKey entity) where TKey : EntityBase;
        Task<int> UpdateAsync<TKey>(TKey entity) where TKey : EntityBase;
        Task<TKey> GetFirstOrDefaultAsync<TKey>(Expression<Func<TKey, bool>> predicate, string includString = null) where TKey : EntityBase;
    
        
        void DetachAsync(T entity);
        void Attach(T Tentity);
        void AttachRange(IEnumerable<T> Tentitys);

    }
}
