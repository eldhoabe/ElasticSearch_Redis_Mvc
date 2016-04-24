using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearch_Redis_Mvc.DataProviders.Repository
{
    /// <summary>
    /// Redis Generic Repository 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IRedisClient _redisClient;
        public GenericRepository(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }
        public IList<T> GetAll()
        {
            return _redisClient.As<T>().GetAll();
        }

        public T Get(Guid id)
        {
            return _redisClient.Get<T>(id.ToString());
        }

        public T Store(T entity)
        {
            return _redisClient.Store<T>(entity);
        }
    }
}