using ElasticSearch_Redis_Mvc.DataProviders;
using ElasticSearch_Redis_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace ElasticSearch_Redis_Mvc.Controllers
{
    /// <summary>
    /// Elastic search controller
    /// </summary>
    public class ElasticController : Controller
    {
        protected ElasticSearchRepository elasticSearch;

        public ElasticController()
        {
            elasticSearch = new ElasticSearchRepository(new Uri("http://localhost:9200/"));
        }

        //Elastic/Search?search=eldho

        /// <summary>
        /// Search using elastic search
        /// </summary>
        /// <param name="search">The search key</param>
        /// <returns></returns>
        public JsonResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {

                var employees = elasticSearch.Search(search);


                return new JsonResult
                {

                    Data = employees,
                    ContentType = "text/plain",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
                return null;
        }




        /// <summary>
        /// Insert employee into elastic search db
        /// </summary>
        /// <param name="employee">The employee</param>
        public void Post([FromBody]Employee employee)
        {
            var result = elasticSearch.InsertData(employee);
        }

    }
}