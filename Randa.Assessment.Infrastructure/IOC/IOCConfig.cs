using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using Randa.Assessment.Application.Services;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Application.Services.DataProcessing;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Contracts.DataProcessor;
using Randa.Assessment.Domain.Contracts.Repository;
using Randa.Assessment.Domain.DataProcessor;
using Randa.Assessment.Domain.DataRecord;
using Randa.Assessment.Domain.Entity;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataProcessor;
using Randa.Assessment.Domain.Validators;
using Randa.Assessment.Infrastructure.Dispatcher;
using Randa.Assessment.Infrastructure.Factory;
using Randa.Assessment.Infrastructure.FileParser;
using Randa.Assessment.Infrastructure.Helper;
using Randa.Assessment.Infrastructure.Helper.Contracts;
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
            
            // CQRS Dispatchers
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();

            // MVC Specific
            builder.RegisterControllers(Assembly.GetCallingAssembly());

            // Factories
            builder.RegisterType<DataParserFactory>().As<IDataParserFactory>();
            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>();
            builder.RegisterType<DataRecordProcessorFactory>().As<IDataRecordProcessorFactory>();

            // Data Processors (All keys should be CAPS)
            builder.RegisterType<EISRecordProcessor>().Keyed<IDataRecordProcessor>("EIS");

            // Commands
            RegisterCommands(builder);

            // Queries
            builder.RegisterType<ReadFileHandler>().As<IQueryHandler<ReadFileQuery, ReadFileResult>>();
            builder.RegisterType<GetUnprocessedRecordsHandler>().As<IQueryHandler<GetUnprocessedRecordsQuery, GetUnprocessedRecordsResult>>();

            // Parsers
            builder.RegisterType<EISDataFileParser>().Keyed<IDataImportParser>(typeof(EISDataRecord));

            // Services
            builder.RegisterType<DataImporterService>().As<IDataImporterService>();
            builder.RegisterType<DataProcessorService>().As<IDataProcessorService>();

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

        private static void RegisterCommands(ContainerBuilder builder)
        {
            var handlerClasses = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(x => x.GetTypes())
                       .Where(type => DoesTypeSupportInterface(type, typeof(ICommandHandler<>)) && type.IsClass).ToList();

            var commandClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(ICommand).IsAssignableFrom(p) && p.IsClass);

            foreach (var command in commandClasses)
            {
                foreach (var handler in handlerClasses)
                {
                    var interfaces = handler.GetInterfaces();
                    if (interfaces.Length > 0)
                    {
                        var @interface = interfaces[0];
                        var argumentType = @interface.GenericTypeArguments[0];
                        if (argumentType == command)
                        {
                            builder.RegisterType(handler).As(@interface);
                        }
                    }
                }
            }
        }

        private static bool DoesTypeSupportInterface(Type type, Type inter)
        {
            if (inter.IsAssignableFrom(type))
                return true;
            if (type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == inter))
                return true;
            return false;
        }
    }
}
