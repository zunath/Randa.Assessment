using System;
using Autofac;
using Randa.Assessment.Application.Services;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Contracts.Repository;
using Randa.Assessment.Domain.Contracts.Security;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Services.Command.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Infrastructure.Dispatcher;
using Randa.Assessment.Infrastructure.Factory;
using Randa.Assessment.Infrastructure.FileParsers;
using Randa.Assessment.Infrastructure.Helpers;
using Randa.Assessment.Infrastructure.Helpers.Contracts;
using Randa.Assessment.Infrastructure.Repository;

namespace Randa.Assessment.Infrastructure.IOC
{
    public class IOCConfig
    {
        public static IContainer Initialize(Type rootType, string connectionString)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType(rootType).As(rootType.GetInterfaces()[0]);
            
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();

            // Factories
            builder.RegisterType<DataParserFactory>().As<IDataParserFactory>();

            // Commands
            builder.RegisterType<ProcessDataImportEventHandler>().As<ICommandHandler<ProcessDataImportEventCommand>>();

            // Queries
            builder.RegisterType<ReadFileHandler>().As<IQueryHandler<ReadFileQuery, ReadFileResult>>();

            // Parsers
            builder.RegisterType<EISDataFileParser>().Keyed<IDataImportParser>(typeof(EISDataRecord));

            // Services
            builder.RegisterType<DataImporterService>().As<IDataImporterService>();
            builder.RegisterType<HashingService>().As<IHashingService>();

            // Repositories
            builder.RegisterType<DataImporterRepository>().As<IDataImporterRepository>()
                .WithParameter("connectionString", connectionString);

            // Helpers
            builder.RegisterType<SQLHelper>().As<ISQLHelper>();

            return builder.Build();
        }
        
    }
}
