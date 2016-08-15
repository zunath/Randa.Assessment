using System.IO;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Services.Command.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Query.DataImporter;

namespace Randa.Assessment.Application.Services
{
    public class DataImporterService: IDataImporterService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        public DataImporterService(IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public void ImportDataFile<T>(string dataSourceId, string filePath)
            where T: IDataRecord
        {
            var result = _queryDispatcher.Execute<ReadFileQuery, ReadFileResult>(
                new ReadFileQuery(filePath, dataSourceId, typeof(T)));
            _commandDispatcher.Execute(ProcessDataImportEventCommand.Create(dataSourceId, Path.GetFileName(filePath), result.Data));
        }
    }
}
