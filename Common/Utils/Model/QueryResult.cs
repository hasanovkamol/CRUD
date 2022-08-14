using System.Collections.Generic;

namespace Common.Utils.Model
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}
