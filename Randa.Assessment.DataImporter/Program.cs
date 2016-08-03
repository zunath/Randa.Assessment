using Autofac;
using Randa.Assessment.DataImporter.Configuration;

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
                app.Run(args);
            }
        }
    }
}
