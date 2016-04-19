using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElasticSearch_Redis_Mvc.Startup))]
namespace ElasticSearch_Redis_Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
