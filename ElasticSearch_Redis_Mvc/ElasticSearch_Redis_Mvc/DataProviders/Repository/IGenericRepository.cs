using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElasticSearch_Redis_Mvc.DataProviders.Repository
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);

        /// <summary>
        /// Save into the redis 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        T Store(T entity);
    }
}
