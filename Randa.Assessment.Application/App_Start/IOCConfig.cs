using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using Randa.Assessment.Domain.Entities;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Validators;
using Randa.Assessment.Infrastructure.Dispatcher;
using Randa.Assessment.Infrastructure.Factory;
using IValidatorFactory = Randa.Assessment.Domain.Contracts.Entities.IValidatorFactory;

namespace Randa.Assessment.Application
{
    public static class IOCConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>();

            // Commands

            // Queries
            //builder.RegisterType<GetActiveDistrictsHandler>().As<IQueryHandler<GetActiveDistrictsQuery, DistrictListQueryResult>>();

            // Validators
            builder.RegisterType<DistrictValidator>()
                .Keyed<IValidator>(typeof(IValidator<District>))
                .As<IValidator>();

            // Repositories

            

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}