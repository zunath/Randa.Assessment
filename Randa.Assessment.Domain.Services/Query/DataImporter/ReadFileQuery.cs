using System;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.DataImporter
{
    public class ReadFileQuery: IQuery
    {
        public string FilePath { get; private set; }
        public string SourceId { get; private set; }
        public Type Type { get; private set; }
        
        public ReadFileQuery(string filePath, string sourceId, Type type)
        {
            FilePath = filePath;
            SourceId = sourceId;
            Type = type;
        }
    }
}
