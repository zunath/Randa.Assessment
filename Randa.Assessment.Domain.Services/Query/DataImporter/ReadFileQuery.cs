using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.DataImporter
{
    public class ReadFileQuery: IQuery
    {
        public string FilePath { get; private set; }
        public string SourceId { get; private set; }
        
        public ReadFileQuery(string filePath, string sourceId)
        {
            FilePath = filePath;
            SourceId = sourceId;
        }
    }
}
