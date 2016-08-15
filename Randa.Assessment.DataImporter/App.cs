using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.DataImporter.DataRecords;

namespace Randa.Assessment.DataImporter
{
    public class App: IApplication
    {
        private readonly IDataImporterService _service;

        public App(IDataImporterService service)
        {
            _service = service;
        }

        public void Run(string[] args)
        {
            string sourceId = args[0];
            string filePath = args[1];

            _service.ImportDataFile<EISDataRecord>(sourceId, filePath);
        }
    }
}
