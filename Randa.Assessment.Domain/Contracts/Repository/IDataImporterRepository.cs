using System.Collections.Generic;
using Randa.Assessment.Domain.DataImporter;

namespace Randa.Assessment.Domain.Contracts.Repository
{
    public interface IDataImporterRepository
    {
        DataImportSourceType GetDataSourceType(string dataSourceId);
        IEnumerable<DataImportSourceKey> GetDataSourceKeys(string dataSourceId);
        DataImportEventRow GetDataImportEventRow(string dataSourceId, string keyHash);


        int Save(DataImportEventRow row);
        int Save(DataImportEvent @event);
        int Save(DataImportEventAudit audit);
    }
}
