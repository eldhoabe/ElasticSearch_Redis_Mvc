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
    public class ElasticController : Controller
    {
        protected ElasticSearchRepository elasticSearch;

        public ElasticController()
        {
            elasticSearch = new ElasticSearchRepository(new Uri("http://localhost:9200/"));
        }

        // GET api/<controller>
        public string Search()
        {


            elasticSearch.Search("Eldho");
            var result = elasticSearch.InsertData(new Employee { FirstName = "Eldho", LastName = "Abe" });
            return "Success";
        }


        // POST api/<controller>
        public void Post([FromBody]Employee employee)
        {
            var result = elasticSearch.InsertData(employee);
        }



        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}