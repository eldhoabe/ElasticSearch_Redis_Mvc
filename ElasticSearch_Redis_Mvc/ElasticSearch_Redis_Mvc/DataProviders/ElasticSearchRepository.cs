using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;
using ElasticSearch_Redis_Mvc.Models;
using System.Threading.Tasks;

namespace ElasticSearch_Redis_Mvc.DataProviders
{
    public class ElasticSearchRepository
    {
        protected ElasticClient Client;

        IndexName index = "employee";

        public ElasticSearchRepository(Uri elasticServerUri)
        {
            var connection = new ConnectionSettings(elasticServerUri).DefaultIndex("employee");
            this.Client = new ElasticClient(connection);

        }

        public void CreateIndex()
        {

            var settings = new IndexSettings();
            settings.NumberOfReplicas = 1;
            settings.NumberOfShards = 1;

            var indexstate = new IndexState();
            indexstate.Settings = settings;


            Client.CreateIndex(index, g => g.Index(index)
                  .InitializeUsing(indexstate)
                  .Mappings(j => j.Map<Employee>(h => h.AutoMap(1))));

        }



        /// <summary>
        /// Insert Data 
        /// </summary>
        /// <returns></returns>
        public IIndexResponse InsertData(Employee employee)
        {
            return Client.Index(employee);
        }


        public List<Employee> Search(string search)
        {
            var response = Client.Search<Employee>(s => s
                                 .AllIndices()
                                 .AllTypes()
                                 .From(0)
                                 .Size(10)
                                 .Query(q =>q
                                 .Term(t => t.FirstName, "Eldho")));

            var result = Client.Search<Employee>(h => h
                                .Query(q => q
                                    .Match(m => m.Field("FirstName").Query(search))));

            var result2 = Client.Search<Employee>(h => h
                         .Type("employee")
                         .Query(k => k
                         .Term(g => g.FirstName, "Eldho")));

            return result.Documents.ToList();
        }


    }
}