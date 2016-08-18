using Randa.Assessment.Domain.Contracts.Repository;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.DataProcessor
{
    public class GetUnprocessedRecordsHandler: IQueryHandler<GetUnprocessedRecordsQuery, GetUnprocessedRecordsResult>
    {
        private readonly IDataImporterRepository _dataImporterRepository;

        public GetUnprocessedRecordsHandler(IDataImporterRepository dataImporterRepository)
        {
            _dataImporterRepository = dataImporterRepository;
        }

        public GetUnprocessedRecordsResult Execute(GetUnprocessedRecordsQuery query)
        {
            var unprocessed = _dataImporterRepository.GetUnprocessedEventRows(query.SourceId);
            return new GetUnprocessedRecordsResult(unprocessed);
        }
    }
}
