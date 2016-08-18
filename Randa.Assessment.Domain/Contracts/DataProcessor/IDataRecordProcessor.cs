using Randa.Assessment.Domain.DataImporter;

namespace Randa.Assessment.Domain.Contracts.DataProcessor
{
    public interface IDataRecordProcessor
    {
        void Process(DataImportEventRow row);
    }
}
