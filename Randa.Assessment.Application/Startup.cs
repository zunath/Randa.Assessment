using Microsoft.Owin;
using Owin;
using Randa.Assessment.Application;

[assembly: OwinStartup(typeof(Startup))]
namespace Randa.Assessment.Application
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
