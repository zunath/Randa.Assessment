using System;
using System.Collections.Generic;
using System.Linq;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter.Result;

namespace Randa.Assessment.Application.Services
{
    public class DataImporterService: IDataImporterService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public DataImporterService(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public void ImportDataFile(string sourceId, string filePath, Type type)
        {
            var query = new ReadFileQuery(filePath, sourceId, type);
            var result = _queryDispatcher.Execute<ReadFileQuery, ReadFileResult>(query);
            List<EISDataRecord> records = result.Data.Cast<EISDataRecord>().ToList();

        }
    }
}
