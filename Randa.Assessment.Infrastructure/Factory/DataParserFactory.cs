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

        public IDataImportParser CreateDataParserForSource(string sourceId)
        {
            var parser = _context.ResolveOptionalKeyed<IDataImportParser>(sourceId);
            return parser;
        }
    }
}
