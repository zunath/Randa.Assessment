using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.DataImporter.Result
{
    public class ReadFileResult : IQueryResult
    {
        public object Data { get; set; }

        public ReadFileResult(object data)
        {
            Data = data;
        }
    }
}
