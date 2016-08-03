using Autofac;
using Randa.Assessment.DataImporter.Configuration;
using Randa.Assessment.Infrastructure.Dapper;

namespace Randa.Assessment.DataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = IOCConfig.Initialize();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                DapperConfig.Initialize();

                app.Run(args);
            }
        }
    }
}
