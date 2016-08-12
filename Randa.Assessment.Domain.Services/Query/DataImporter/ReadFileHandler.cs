using System.Collections;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.DataImporter
{
    public class ReadFileHandler: IQueryHandler<ReadFileQuery, ReadFileResult>
    {
        private readonly IDataParserFactory _factory;

        public ReadFileHandler(IDataParserFactory factory)
        {
            _factory = factory;
        }

        public ReadFileResult Execute(ReadFileQuery query)
        {
            IDataImportParser parser = _factory.CreateDataParserForSource(query.SourceId, query.Type);
            IEnumerable data = parser.ParseFile(query.FilePath);
            return new ReadFileResult(data);
        }
    }
}
