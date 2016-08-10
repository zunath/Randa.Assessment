using System;
using System.Collections.Generic;
using System.Linq;
using Randa.Assessment.Application.Services.Contracts;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter.Result;

namespace Randa.Assessment.Application.Services
{
    public class DataImporterService: IDataImporterService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IDataImporterRepository _repo;
        public DataImporterService(IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher,
            IDataImporterRepository repo)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
            _repo = repo;
        }

        public void ImportDataFile(string sourceId, string filePath, Type type)
        {
            var query = new ReadFileQuery(filePath, sourceId, type);
            var result = _queryDispatcher.Execute<ReadFileQuery, ReadFileResult>(query);
            List<EISDataRecord> records = result.Data.Cast<EISDataRecord>().ToList();
            DataImportSourceType sourceType = _repo.GetDataSourceType(sourceId);




        }
    }
}
