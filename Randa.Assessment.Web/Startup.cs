using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Randa.Assessment.Web.Startup))]
namespace Randa.Assessment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
