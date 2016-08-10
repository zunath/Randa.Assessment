using Randa.Assessment.Domain.DataImporter.Enums;

namespace Randa.Assessment.Domain.DataImporter
{
    public class DataImportSourceType
    {
        public string DataSourceId { get; set; }
        public string Name { get; set; }
        public DataImportParserType ParserType { get; set; }
    }
}
