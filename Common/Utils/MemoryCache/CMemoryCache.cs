using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Utils.MemoryCache
{
    public class CMemoryCache : ICMemoryCache
    {
        private readonly IMemoryCache memoryCache;
        public CMemoryCache(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public void Add<T>(T objCache, string key)
        {
            if (objCache != null)
            {
                memoryCache.Set(
                     key,
                     objCache,
                    DateTime.Now.AddMinutes(1440)
                    );
            }
        }
        public void Clear(string key)
        {
            memoryCache.Remove(key);
        }
        public bool Exists(string key)
        {
            object getValue;
            return memoryCache.TryGetValue(key, out getValue);
        }
        public bool Get<T>(string key, out T value)
        {
            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                    return false;
                }
                memoryCache.TryGetValue<T>(key, out value);
                //value =  (T)memoryCache[key];
            }
            catch
            {
                value = default(T);
                return false;
            }
            return true;
        }
        public List<T> GetDataInCachByQuery<T>(IQueryable<T> query)
        {
            if (Exists(typeof(T).FullName))
            {
                return memoryCache.Get<List<T>>(typeof(T).FullName);// memoryCache[typeof(T).FullName] as List<T>;
            }
            else
            {
                List<T> result = query.ToList();
                Add<List<T>>(result, typeof(T).FullName);
                return result;
            }
        }
        public async Task<List<T>> GetDataInCachByQueryAsync<T>(IQueryable<T> query)
        {
            if (Exists(typeof(T).FullName))
            {
                return memoryCache.Get<List<T>>(typeof(T).FullName);//memoryCache[typeof(T).FullName] as List<T>;
            }
            else
            {
                List<T> result = await query.ToListAsync();
                Add<List<T>>(result, typeof(T).FullName);
                return result;
            }
        }

        public async Task<List<T>> GetDataInCachByQueryAndTableNameAsync<T>(IQueryable<T> query, string tableName)
        {
            tableName = tableName.ToLower();
            if (Exists(tableName))
            {
                return memoryCache.Get<List<T>>(tableName);//memoryCache[typeof(T).FullName] as List<T>;
            }
            else
            {
                List<T> result = await query.ToListAsync();
                Add<List<T>>(result, tableName);
                return result;
            }
        }
    }
}
