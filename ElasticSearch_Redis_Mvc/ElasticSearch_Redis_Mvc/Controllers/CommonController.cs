using ElasticSearch_Redis_Mvc.DataProviders;
using ElasticSearch_Redis_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;

namespace ElasticSearch_Redis_Mvc.Controllers
{
    public class CommonController : Controller
    {
        private readonly ElasticSearchRepository elasticSearch;
        private readonly DataAccessPoint _dataAccessPoint;

        public CommonController()
        {
            elasticSearch = new ElasticSearchRepository(new Uri("http://localhost:9200/"));
            _dataAccessPoint = new DataAccessPoint();
        }

        //
        // GET: /Common/

        public string Index(string search)
        {
            if (string.IsNullOrEmpty(search))
                search = "Eldho";

            Create(new Employee { FirstName = search, LastName = search });

            return "A employee is inserted";

        }

        /// <summary>
        /// This create and insert data in elastic search and redis 
        /// </summary>
        /// <param name="employee"></param>
        public void Create(Employee employee)
        {

            elasticSearch.CreateIndex();
            elasticSearch.InsertData(employee);

            _dataAccessPoint.EmployeeRepository.Store(employee);

        }
    }
}