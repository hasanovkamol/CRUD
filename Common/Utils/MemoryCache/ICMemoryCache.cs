using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Utils.MemoryCache
{
    public interface ICMemoryCache
    {
        List<T> GetDataInCachByQuery<T>(IQueryable<T> query);
        Task<List<T>> GetDataInCachByQueryAsync<T>(IQueryable<T> query);

        Task<List<T>> GetDataInCachByQueryAndTableNameAsync<T>(IQueryable<T> query, string tableName);
        void Clear(string key);
    }
}
