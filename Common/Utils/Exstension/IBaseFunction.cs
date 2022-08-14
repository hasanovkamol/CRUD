using Common.Utils.Model;
using System.Threading.Tasks;

namespace Common.Utils.Exstension
{
    public interface IBaseFunction<EntityBase,TKey>
    {
        /// <summary>
        /// get the list into a table
        /// </summary>
        /// <param name="uTabl"></param>
        /// <returns></returns>
        Task<QueryResult<EntityBase>> GetQuerResult(TableMetaData uTabl);
        /// <summary>
        /// get model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EntityBase> GetById(TKey id);
        /// <summary>
        /// update model to DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Response> Update(EntityBase entity);
        /// <summary>
        /// Add the model to the DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Response> Create(EntityBase entity);
        /// <summary>
        /// Delet model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> onDelete(TKey id);

    }
}
