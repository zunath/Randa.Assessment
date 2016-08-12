using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using Randa.Assessment.Infrastructure.IOC;

namespace Randa.Assessment.Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(
                new AutofacDependencyResolver(
                    IOCConfig.Initialize(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString())
                )
            );
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();
            
        }
    }
}
