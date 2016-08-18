using System.Collections.Generic;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.DataProcessor
{
    public class GetUnprocessedRecordsResult: IQueryResult
    {
        public IEnumerable<DataImportEventRow> DataRows { get; set; }

        public GetUnprocessedRecordsResult(IEnumerable<DataImportEventRow> rows)
        {
            DataRows = rows;
        }
    }
}
