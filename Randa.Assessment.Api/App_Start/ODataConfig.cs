using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Randa.Assessment.Api.Models;

namespace Randa.Assessment.Api
{
    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<District>("District");

            config.MapODataServiceRoute("ODataRoute", "api", builder.GetEdmModel());
        }
    }
}