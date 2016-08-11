using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Infrastructure.Helpers;
using Randa.Assessment.Infrastructure.Helpers.Contracts;

namespace Randa.Assessment.Infrastructure.Repository
{
    public class DataImporterRepository: BaseRepository, IDataImporterRepository
    {
        private readonly ISQLHelper _sqlHelper;

        public DataImporterRepository(string connectionString, ISQLHelper sqlHelper)
            : base(connectionString)
        {
            _sqlHelper = sqlHelper;
        }

        public DataImportSourceType GetDataSourceType(string dataSourceId)
        {
            return WithConnection(c => c.Query<DataImportSourceType>("SELECT DataSourceId, Name, ParserType FROM DataImportSourceType WHERE DataSourceId=@dataSourceID", new {dataSourceId}).Single());
        }

        public IEnumerable<DataImportSourceKey> GetDataSourceKeys(string dataSourceId)
        {
            return WithConnection(c => c.Query<DataImportSourceKey>("SELECT DataImportSourceKeyId, DataSourceId, [Key] FROM DataImportSourceKey WHERE DataSourceId=@dataSourceId", new {dataSourceId}).ToList());
        }

        public DataImportEventRow GetDataImportEventRow(string dataSourceId, string keyHash)
        {
            return WithConnection(c => c.Query<DataImportEventRow>("SELECT DataSourceId, KeyHash, JSON, DataHash, LastUpdated FROM DataImportEventRow WHERE DataSourceId=@dataSourceId AND KeyHash=@keyHash", new {dataSourceId, keyHash}).SingleOrDefault());
        }

        public int Save(DataImportEventRow row)
        {
            return WithConnection(c =>
            {
                string sql = _sqlHelper.CreateSaveString("KeyHash", row);
                return c.Execute(sql);
            });
        }

        public int Save(DataImportEvent @event)
        {
            return WithConnection(c =>
            {
                string sql = _sqlHelper.CreateSaveString("EventId", @event);
                return c.Execute(sql);
            });
        }
    }
}
