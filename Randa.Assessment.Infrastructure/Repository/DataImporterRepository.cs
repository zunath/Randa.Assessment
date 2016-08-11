using System.Collections.Generic;
using System.Data.SqlClient;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Infrastructure.Helpers.Contracts;

namespace Randa.Assessment.Infrastructure.Repository
{
    public class DataImporterRepository: BaseRepository, IDataImporterRepository
    {
        public DataImporterRepository(string connectionString, ISQLHelper sqlHelper) 
            : base(connectionString, sqlHelper)
        {
        }

        public DataImportSourceType GetDataSourceType(string dataSourceId)
        {
            return AdHocSQLSingle<DataImportSourceType>("SELECT DataSourceId, Name, ParserType FROM DataImportSourceType WHERE DataSourceId=@dataSourceID", 
                new SqlParameter("dataSourceId", dataSourceId));
        }

        public IEnumerable<DataImportSourceKey> GetDataSourceKeys(string dataSourceId)
        {
            return AdHocSQLMany<DataImportSourceKey>("SELECT DataImportSourceKeyId, DataSourceId, [Key] FROM DataImportSourceKey WHERE DataSourceId=@dataSourceId", 
                new SqlParameter("dataSourceId", dataSourceId));
        }

        public DataImportEventRow GetDataImportEventRow(string dataSourceId, string keyHash)
        {
            return AdHocSQLSingle<DataImportEventRow>("SELECT DataSourceId, EventId, KeyHash, JSON, DataHash, LastUpdated FROM DataImportEventRow WHERE DataSourceId=@dataSourceId AND KeyHash=@keyHash", 
                new SqlParameter("dataSourceID", dataSourceId), 
                new SqlParameter("keyHash", keyHash));
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
