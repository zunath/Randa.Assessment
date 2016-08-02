using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.Repository;

namespace Randa.Assessment.Infrastructure.Repository
{
    public class DataImporterRepository: IDataImporterRepository
    {
        public DataSourceType GetDataSourceType(string dataSourceId)
        {
            // TODO: Get from DB
            return new DataSourceType
            {
                ParserType = DataParserType.Delimited,
                DataSourceId = dataSourceId,
                Name = "EIS"
            };
        }
    }
}
