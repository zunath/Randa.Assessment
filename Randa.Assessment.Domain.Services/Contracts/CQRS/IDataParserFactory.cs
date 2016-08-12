using System;
using Randa.Assessment.Domain.Contracts.DataImporter;

namespace Randa.Assessment.Domain.Services.Contracts.CQRS
{
    public interface IDataParserFactory
    {
        IDataImportParser CreateDataParserForSource(string sourceId, Type type);
    }
}
