using System.Configuration;
using Autofac;
using Randa.Assessment.Infrastructure.IOC;

namespace Randa.Assessment.DataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = IOCConfig.Initialize(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), typeof(App));

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();

                app.Run(args);
            }
        }
    }
}
