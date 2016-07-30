using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Randa.Assessment.Api.App_Start;

namespace Randa.Assessment.Api
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            IOCConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(config =>
            {
                config.EnableCors();
                ODataConfig.Register(config);
                WebApiConfig.Register(config);
            });
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}