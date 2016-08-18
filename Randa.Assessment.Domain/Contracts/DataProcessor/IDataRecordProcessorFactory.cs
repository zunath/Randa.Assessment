using Randa.Assessment.Domain.Contracts.DataImporter;

namespace Randa.Assessment.Domain.Contracts.DataProcessor
{
    public interface IDataRecordProcessorFactory
    {
        IDataRecordProcessor CreateDataRecordProcessor(string dataSourceId);
    }
}
