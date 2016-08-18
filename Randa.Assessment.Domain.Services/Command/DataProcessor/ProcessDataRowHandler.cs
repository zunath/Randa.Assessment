using Newtonsoft.Json;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Contracts.DataProcessor;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Command.DataProcessor
{
    public class ProcessDataRowHandler : ICommandHandler<ProcessDataRowCommand>
    {
        private readonly IDataRecordProcessorFactory _factory;
        public ProcessDataRowHandler(IDataRecordProcessorFactory factory)
        {
            _factory = factory;
        }

        public void Execute(ProcessDataRowCommand rowCommand)
        {
            IDataRecordProcessor processor = _factory.CreateDataRecordProcessor(rowCommand.DataSourceId);
            processor.Process(rowCommand.DataRow);
        }
    }
}
