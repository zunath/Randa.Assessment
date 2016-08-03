using System.Collections.Generic;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.Repository;

namespace Randa.Assessment.Infrastructure.Repository
{
    public class DataImporterRepository: IDataImporterRepository
    {
        public DataImportSourceType GetDataSourceType(string dataSourceId)
        {
            // TODO: Get from DB
            return new DataImportSourceType
            {
                ImportParserType = DataImportParserType.Delimited,
                DataSourceId = dataSourceId,
                Name = "EIS"
            };
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
