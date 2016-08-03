using System.Configuration;
using Autofac;
using Autofac.Core;
using Randa.Assessment.Application.Services;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter.Handler;
using Randa.Assessment.Domain.Services.Query.DataImporter.Result;
using Randa.Assessment.Infrastructure.Dispatcher;
using Randa.Assessment.Infrastructure.Factory;
using Randa.Assessment.Infrastructure.FileParsers;
using Randa.Assessment.Infrastructure.Repository;

namespace Randa.Assessment.DataImporter.Configuration
{
    public class IOCConfig
    {
        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<App>().As<IApplication>();

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();

            // Factories
            builder.RegisterType<DataParserFactory>().As<IDataParserFactory>();

            // Queries
            builder.RegisterType<ReadFileHandler>().As<IQueryHandler<ReadFileQuery, ReadFileResult>>();

            // Parsers
            builder.RegisterType<EISDataFileParser>().Keyed<IDataImportParser>(typeof(EISDataRecord));

            // Services
            builder.RegisterType<DataImporterService>().As<IDataImporterService>();

            // Repositories
            builder.RegisterType<DataImporterRepository>().As<IDataImporterRepository>()
                .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            return builder.Build();
        }
    }
}
