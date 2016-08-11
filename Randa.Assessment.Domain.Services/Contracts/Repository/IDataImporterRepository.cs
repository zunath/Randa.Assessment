using System.Collections.Generic;
using System.Threading.Tasks;
using Randa.Assessment.Domain.DataImporter;

namespace Randa.Assessment.Domain.Services.Contracts.Repository
{
    public interface IDataImporterRepository
    {
        DataImportSourceType GetDataSourceType(string dataSourceId);
        IEnumerable<DataImportSourceKey> GetDataSourceKeys(string dataSourceId);
        DataImportEventRow GetDataImportEventRow(string dataSourceId, string keyHash);


        int Save(DataImportEventRow row);
        int Save(DataImportEvent @event);
    }
}
