using System.Collections.Generic;
using Randa.Assessment.Domain.DataImporter;

namespace Randa.Assessment.Domain.Services.Contracts.Repository
{
    public interface IDataImporterRepository
    {
        DataImportSourceType GetDataSourceType(string dataSourceId);
        IEnumerable<DataImportSourceKey> GetDataSourceKeys();
    }
}
