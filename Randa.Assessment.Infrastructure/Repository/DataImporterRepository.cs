using System.Data.SqlClient;
using Randa.Assessment.Domain.Contracts.Repository;
using Randa.Assessment.Domain.DataImporter;
using System.Collections.Generic;
using Randa.Assessment.Infrastructure.Helper.Contracts;

namespace Randa.Assessment.Infrastructure.Repository
{
    public class DataImporterRepository: BaseRepository, IDataImporterRepository
    {
        public DataImporterRepository(string connectionString, ISQLHelper sqlHelper) 
            : base(connectionString, sqlHelper)
        {
        }
        
        public DataImportEventRow GetDataImportEventRow(string dataSourceId, string keyHash)
        {
            return AdHocSQLSingle<DataImportEventRow>("SELECT DataSourceId, EventId, KeyHash, JSON, DataHash, DateLastUpdated FROM DataImportEventRow WHERE DataSourceId=@dataSourceId AND KeyHash=@keyHash", 
                new SqlParameter("dataSourceId", dataSourceId), 
                new SqlParameter("keyHash", keyHash));
        }

        public IEnumerable<DataImportEventRow> GetUnprocessedEventRows(string dataSourceId)
        {
            return AdHocSQLMany<DataImportEventRow>("SELECT DataSourceId, EventId, KeyHash, JSON, DataHash, DateLastUpdated FROM DataImportEventRow WHERE DataSourceId=@dataSourceId",
                new SqlParameter("dataSourceId", dataSourceId));
        }

        public int Save(DataImportEventRow row)
        {
            return SaveEntity(row, "KeyHash", null, false);
        }

        public int Save(DataImportEvent @event)
        {
            return SaveEntity(@event, "EventId");
        }

        public int Save(DataImportEventAudit audit)
        {
            return SaveEntity(audit, "EventAuditId");
        }
    }
}
