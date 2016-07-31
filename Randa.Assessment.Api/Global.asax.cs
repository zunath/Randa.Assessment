using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Randa.Assessment.Api
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(config =>
            {
                config.EnableCors();
                IOCConfig.Initialize(config);
                ODataConfig.Register(config);
                WebApiConfig.Register(config);
                
            });
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}