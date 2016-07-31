using System;
using Autofac;
using Randa.Assessment.CQRS.Contracts;

namespace Randa.Assessment.CQRS.Dispatchers
{
    public class QueryDispatcher: IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public TResult Execute<TQuery, TResult>(TQuery query) 
            where TQuery : IQuery
            where TResult: IQueryResult
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = _context.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
            {
                throw new Exception("Query handler not found. Query name: " + nameof(query));
            }

            return handler.Execute(query);
        }
    }
}
