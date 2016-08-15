using Randa.Assessment.Domain.Contracts.DataImporter;

namespace Randa.Assessment.Application.Services.Contracts
{
    public interface IDataImporterService
    {
        void ImportDataFile<T>(string dataSourceId, string filePath)
            where T: IDataRecord;
    }
}
