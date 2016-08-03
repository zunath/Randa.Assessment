using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using Randa.Assessment.Domain.Entities;
using Randa.Assessment.Domain.Services.Command;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Domain.Services.Query;
using Randa.Assessment.Domain.Services.Query.Districts;
using Randa.Assessment.Domain.Services.Query.Districts.Handler;
using Randa.Assessment.Domain.Services.Query.Districts.Result;
using Randa.Assessment.Domain.Validators;
using Randa.Assessment.Infrastructure.Dispatcher;
using Randa.Assessment.Infrastructure.Factory;
using Randa.Assessment.Infrastructure.Repository;
using IValidatorFactory = Randa.Assessment.Domain.Contracts.IValidatorFactory;

namespace Randa.Assessment.Application
{
    public static class IOCConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<Command>().As<ICommand>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>();

            // Commands

            // Queries
            builder.RegisterType<GetActiveDistrictsHandler>().As<IQueryHandler<GetActiveDistrictsQuery, DistrictListQueryResult>>();

            // Validators
            builder.RegisterType<DistrictValidator>()
                .Keyed<IValidator>(typeof(IValidator<District>))
                .As<IValidator>();

            // Repositories
            builder.RegisterType<DistrictRepository>().As<IDistrictRepository>();

            

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}