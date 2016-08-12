using System;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using Randa.Assessment.Application.Services;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Contracts.Repository;
using Randa.Assessment.Domain.Contracts.Security;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Entities;
using Randa.Assessment.Domain.Services.Command.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Domain.Validators;
using Randa.Assessment.Infrastructure.Dispatcher;
using Randa.Assessment.Infrastructure.Factory;
using Randa.Assessment.Infrastructure.FileParsers;
using Randa.Assessment.Infrastructure.Helpers;
using Randa.Assessment.Infrastructure.Helpers.Contracts;
using Randa.Assessment.Infrastructure.Repository;
using IValidatorFactory = Randa.Assessment.Domain.Contracts.Entities.IValidatorFactory;

namespace Randa.Assessment.Infrastructure.IOC
{
    public class IOCConfig
    {
        public static IContainer Initialize(string connectionString, Type rootType = null)
        {
            var builder = new ContainerBuilder();

            if (rootType != null)
            {
                builder.RegisterType(rootType).As(rootType.GetInterfaces()[0]);
            }
            
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();

            // MVC Specific
            builder.RegisterControllers(Assembly.GetCallingAssembly());

            // Factories
            builder.RegisterType<DataParserFactory>().As<IDataParserFactory>();
            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>();

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

            // Validators
            builder.RegisterType<DistrictValidator>()
                .Keyed<IValidator>(typeof(IValidator<District>))
                .As<IValidator>();

            return builder.Build();
        }
        
    }
}
