using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Randa.Assessment.CQRS.Commands;
using Randa.Assessment.CQRS.Contracts;
using Randa.Assessment.CQRS.Dispatchers;
using Randa.Assessment.CQRS.Queries;
using Randa.Assessment.CQRS.Queries.Handlers;
using Randa.Assessment.Domain.Entities;

namespace Randa.Assessment.Api
{
    public static class IOCConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<Command>().As<ICommand>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            
            builder.RegisterType<GetActiveDistrictsHandler>().As<IQueryHandler<GetActiveDistrictsQuery, List<District>>>();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}