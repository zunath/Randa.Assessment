using System;
using System.Collections;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Command.DataImporter.Commands
{
    public class ProcessDataImportEventCommand: ICommand
    {
        public string DataSourceId { get; private set; }
        public string FileName { get; private set; }
        public IEnumerable Data { get; private set; }

        public ProcessDataImportEventCommand(string dataSourceId, string fileName, IEnumerable data)
        {
            DataSourceId = dataSourceId;
            FileName = fileName;
            Data = data;
        }
    }
}
