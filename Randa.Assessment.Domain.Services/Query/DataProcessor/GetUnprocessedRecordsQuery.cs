using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.DataProcessor
{
    public class GetUnprocessedRecordsQuery: IQuery
    {
        public string SourceId { get; private set; }

        public static GetUnprocessedRecordsQuery Create(string sourceId)
        {
            return new GetUnprocessedRecordsQuery
            {
                SourceId = sourceId
            };
        }
    }
}
