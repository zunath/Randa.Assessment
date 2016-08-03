using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dapper.Extensions.Linq.Extensions;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.Repository;

namespace Randa.Assessment.Infrastructure.Repository
{
    public class DataImporterRepository: BaseRepository, IDataImporterRepository
    {
        public DataImporterRepository(string connectionString) 
            : base(connectionString) { }

        public DataImportSourceType GetDataSourceType(string dataSourceId)
        {
            return WithConnection(c => c.Get<DataImportSourceType>(dataSourceId));
        }

        public IEnumerable<DataImportSourceKey> GetDataSourceKeys()
        {
            // TODO: Get from DB
            List<DataImportSourceKey> keys = new List<DataImportSourceKey>
            {
                new DataImportSourceKey {DataImportSourceKeyId = 1, SourceId = "EIS", Key = "USID"}
            };

            return keys;
        }

    }
}
