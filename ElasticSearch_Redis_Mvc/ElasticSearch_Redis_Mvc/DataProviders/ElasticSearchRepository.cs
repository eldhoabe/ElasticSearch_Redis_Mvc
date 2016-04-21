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
        protected readonly ElasticClient Client;
        private IndexName index = "employee";

        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="elasticServerUri">The elastic server uri</param>
        public ElasticSearchRepository(Uri elasticServerUri)
        {
            var connection = new ConnectionSettings(elasticServerUri).DefaultIndex("employee");
            this.Client = new ElasticClient(connection);
        }

        /// <summary>
        /// Create index for the docuemnt
        /// </summary>
        public void CreateIndex()
        {

            var settings = new IndexSettings();
            settings.NumberOfReplicas = 1;
            settings.NumberOfShards = 1;

            var indexstate = new IndexState();
            indexstate.Settings = settings;


            Client.CreateIndex(index, g => g
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


        /// <summary>
        /// Match query search on first name
        /// </summary>
        /// <param name="search">The search key value</param>
        /// <returns></returns>
        public List<Employee> Search(string search)
        {

            var result = Client.Search<Employee>(h => h
                                .Query(q => q
                                    .Match(m => m.Field("firstName").Query(search))));

            return result.Documents.ToList();
        }


    }
}