using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.DataRecord;

namespace Randa.Assessment.DataImporter
{
    public class App: IApplication
    {
        private readonly IDataImporterService _dataImporterService;
        private readonly IDataProcessorService _dataProcessorService;

        public App(IDataImporterService dataImporterService,
            IDataProcessorService dataProcessorService)
        {
            _dataImporterService = dataImporterService;
            _dataProcessorService = dataProcessorService;
        }

        public void Run(string[] args)
        {
            string sourceId = args[0];
            string filePath = args[1];

            _dataImporterService.ImportDataFile<EISDataRecord>(sourceId, filePath);
            _dataProcessorService.ProcessData<EISDataRecord>(sourceId);
        }
    }
}
