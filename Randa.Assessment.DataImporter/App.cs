using System.Collections.Generic;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter.Result;

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

            _service.ImportDataFile(sourceId, filePath, typeof(EISDataRecord));
        }
    }
}
