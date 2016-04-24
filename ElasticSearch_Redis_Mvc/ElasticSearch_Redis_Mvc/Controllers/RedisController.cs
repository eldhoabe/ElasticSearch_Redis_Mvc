using ElasticSearch_Redis_Mvc.DataProviders;
using ElasticSearch_Redis_Mvc.DataProviders.Repository;
using ElasticSearch_Redis_Mvc.Models;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ElasticSearch_Redis_Mvc.Controllers
{
    public class RedisController : Controller
    {
        private readonly DataAccessPoint _dataAccessPoint;

        public RedisController()
        {
            _dataAccessPoint = new DataAccessPoint();
        }

        //
        // GET: /Redis/
        public JsonResult Index()
        {

            var result = _dataAccessPoint.EmployeeRepository.GetAll();

            return Json(result,JsonRequestBehavior.AllowGet);
        }


        public void Post([FromBody]Employee employee)
        {
            _dataAccessPoint.EmployeeRepository.Store(employee);
        }
    }
}