using Common.Utils.Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Utils.Exstension
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, TableMetaData queryObj, string defaultSortField, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (string.IsNullOrWhiteSpace(queryObj.sortField) || !columnsMap.ContainsKey(queryObj.sortField))
                return query.OrderByDescending(columnsMap[defaultSortField]);

            if (queryObj.sortOrder == 1)
                return query.OrderBy(columnsMap[queryObj.sortField]);

            else
                return query.OrderByDescending(columnsMap[queryObj.sortField]);
        }

        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, string queryObj, Dictionary<string, Expression<Func<T, bool>>> columnsMap)
        {
            if (string.IsNullOrWhiteSpace(queryObj) || !columnsMap.ContainsKey(queryObj))
                return query;

            return query.Where(columnsMap[queryObj]);
        }

        public static IQueryable<T> FilterQueryableWithDelegate<T>(
            this IQueryable<T> query,
            TableMetaData utData,
            Func<string, int, Dictionary<string, Expression<Func<T, bool>>>> filterDelegate
            )
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item_filter = serializer.Deserialize<object>(utData.filters);
            foreach (dynamic item in item_filter)
            {
                string value = "";
                string key = item.Key;
                foreach (dynamic item2 in item.Value)
                {
                    value += item2.Value;
                    break;
                }
                int id = 0;
                int.TryParse(value, out id);

                query = query.ApplyFiltering(key, filterDelegate(value, id));
            }
            return query;
        }
    }
}
