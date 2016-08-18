using System;
using Randa.Assessment.Domain.Contracts.DataImporter;

namespace Randa.Assessment.Domain.Services.Contracts.DataImporter
{
    public interface IDataParserFactory
    {
        IDataImportParser CreateDataParserForSource(string sourceId, Type type);
    }
}
