using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Randa.Assessment.Domain.Services.Command;
using Randa.Assessment.Domain.Services.Contracts;
using Randa.Assessment.Domain.Services.Query;
using Randa.Assessment.Domain.Services.Query.Handlers;
using Randa.Assessment.Domain.Services.Query.Results;
using Randa.Assessment.Domain.Services.Repository;
using Randa.Assessment.Infrastructure.Dispatcher;
using Randa.Assessment.Infrastructure.Repository;

namespace Randa.Assessment.Application
{
    public static class IOCConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Command>().As<ICommand>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();

            // Commands

            // Queries
            builder.RegisterType<GetActiveDistrictsHandler>().As<IQueryHandler<GetActiveDistrictsQuery, DistrictListQueryResult>>();


            // Repositories
            builder.RegisterType<DistrictRepository>().As<IDistrictRepository>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}