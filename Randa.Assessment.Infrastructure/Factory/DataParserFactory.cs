using System;
using Autofac;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.DataImporter;

namespace Randa.Assessment.Infrastructure.Factory
{
    public class DataParserFactory: IDataParserFactory
    {
        private readonly IComponentContext _context;

        public DataParserFactory(IComponentContext context)
        {
            _context = context;
        }

        public IDataImportParser<T> CreateDataParserForSource<T>(string sourceId)
        {
            var parser = _context.Resolve<IDataImportParser<T>>();
            return parser;
        }
    }
}
