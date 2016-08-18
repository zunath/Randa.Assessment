using System;
using Autofac;
using Randa.Assessment.Domain.Contracts.DataImporter;
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

        public IDataImportParser CreateDataParserForSource(string sourceId, Type type)
        {
            var parser = _context.ResolveKeyed<IDataImportParser>(type);
            return parser;
        }
    }
}
