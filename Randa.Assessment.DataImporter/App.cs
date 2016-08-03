using System.Collections.Generic;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter;
using Randa.Assessment.Domain.Services.Query.DataImporter.Result;

namespace Randa.Assessment.DataImporter
{
    public class App: IApplication
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public App(IQueryDispatcher queryDispatcher, 
            ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public void Run(string[] args)
        {
            string sourceId = args[0];
            string filePath = args[1];

            var query = new ReadFileQuery(filePath, sourceId);
            var results = _queryDispatcher.Execute<ReadFileQuery, ReadFileResult>(query);

        }
    }
}
