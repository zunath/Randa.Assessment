using Randa.Assessment.Domain.DataImporter;

namespace Randa.Assessment.Domain.Services.Contracts.Repository
{
    public interface IDataImporterRepository
    {
        DataSourceType GetDataSourceType(string dataSourceId);
    }
}
