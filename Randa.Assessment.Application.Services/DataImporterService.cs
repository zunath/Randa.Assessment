using System;
using System.IO;
using Randa.Assessment.Application.Services.Contracts;
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

        public void ImportDataFile(string dataSourceId, string filePath, Type type)
        {
            var result = _queryDispatcher.Execute<ReadFileQuery, ReadFileResult>(
                new ReadFileQuery(filePath, dataSourceId, type));
            _commandDispatcher.Execute(new ProcessDataImportEventCommand(dataSourceId, Path.GetFileName(filePath), result.Data));
        }
    }
}
