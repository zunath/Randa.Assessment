using System.Threading.Tasks;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Services.Command.DataProcessor;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Query.DataProcessor;

namespace Randa.Assessment.Application.Services.DataProcessing
{
    public class DataProcessorService: IDataProcessorService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public DataProcessorService(IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public void ProcessData<T>(string dataSourceId) 
            where T : IDataRecord
        {
            var result = _queryDispatcher.Execute<GetUnprocessedRecordsQuery, GetUnprocessedRecordsResult>(
                GetUnprocessedRecordsQuery.Create(dataSourceId));

            Parallel.ForEach(result.DataRows, (record) =>
            {
                _commandDispatcher.Execute(ProcessDataRowCommand.Create(record, dataSourceId));
            });

        }
    }
}
