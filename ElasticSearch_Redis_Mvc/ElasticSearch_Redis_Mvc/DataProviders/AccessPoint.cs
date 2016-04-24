using ElasticSearch_Redis_Mvc.DataProviders.Repository;
using ElasticSearch_Redis_Mvc.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearch_Redis_Mvc.DataProviders
{
    /// <summary>
    /// Data Access Point
    /// </summary>
    public class DataAccessPoint
    {
        public IRedisClientsManager ClientsManager;
        private const string RedisUri = "localhost";

        public DataAccessPoint()
        {
            ClientsManager = new PooledRedisClientManager(RedisUri);
        }


        private  IGenericRepository<Employee> _employeeRepository;

        public  IGenericRepository<Employee> EmployeeRepository
        {
            get { return _employeeRepository = new GenericRepository<Employee>(ClientsManager.GetClient()); }
        }


    }
}