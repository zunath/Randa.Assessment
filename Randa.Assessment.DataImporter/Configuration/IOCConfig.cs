using Autofac;
using Autofac.Core;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter.Handler;
using Randa.Assessment.Domain.Services.Query.DataImporter.Result;
using Randa.Assessment.Infrastructure.Dispatcher;
using Randa.Assessment.Infrastructure.Factory;
using Randa.Assessment.Infrastructure.FileParsers;

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
            builder.RegisterType<EISDataFileParser>().As<IDataImportParser<EISDataRecord>>();

            return builder.Build();
        }
    }
}
