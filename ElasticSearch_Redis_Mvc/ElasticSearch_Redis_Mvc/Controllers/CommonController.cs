using ElasticSearch_Redis_Mvc.DataProviders;
using ElasticSearch_Redis_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        [HttpPost]
        public ActionResult Index(Employee data)
        {
            Post(data);

            return View();
        }

        //[HttpPost]
        private void Post(Employee employee)
        {
            //if (String.IsNullOrEmpty(search))
            //    throw new ArgumentNullException("The search is null or empty");

            elasticSearch.CreateIndex();
            //var employee = new Employee { FirstName = search, LastName = search, Id = 1 };
            elasticSearch.InsertData(employee);

            _dataAccessPoint.EmployeeRepository.Store(employee);
        }
    }
}