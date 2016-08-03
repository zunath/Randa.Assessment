using Randa.Assessment.Domain.Services.Contracts.DataImporter;

namespace Randa.Assessment.Domain.Services.Contracts.CQRS
{
    public interface IDataParserFactory
    {
        IDataImportParser<T> CreateDataParserForSource<T>(string sourceId);
    }
}
