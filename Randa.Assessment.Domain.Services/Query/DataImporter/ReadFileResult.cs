using System.Collections;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.DataImporter
{
    public class ReadFileResult : IQueryResult
    {
        public IEnumerable Data { get; set; }

        public ReadFileResult(IEnumerable data)
        {
            Data = data;
        }
    }
}
