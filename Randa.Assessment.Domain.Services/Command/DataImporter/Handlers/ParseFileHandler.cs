using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Command.DataImporter.Commands;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.Repository;

namespace Randa.Assessment.Domain.Services.Command.DataImporter.Handlers
{
    public class ParseFileHandler: ICommandHandler<ParseFileCommand>
    {
        private readonly IDataImporterRepository _dataRepo;

        public ParseFileHandler(IDataImporterRepository dataRepo)
        {
            _dataRepo = dataRepo;
        }

        public void Execute(ParseFileCommand command)
        {
            DataSourceType eventType = _dataRepo.GetDataSourceType(command.DataSourceId);


        }
    }
}
