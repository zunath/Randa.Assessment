using System.Collections.Generic;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Command.DataProcessor
{
    public class ProcessDataRowCommand: ICommand
    {
        public DataImportEventRow DataRow { get; private set; }
        public string DataSourceId { get; private set; }


        public static ProcessDataRowCommand Create(DataImportEventRow dataRow, string dataSourceId)
        {
            return new ProcessDataRowCommand
            {
                DataRow = dataRow,
                DataSourceId = dataSourceId
            };
        }
    }
}
