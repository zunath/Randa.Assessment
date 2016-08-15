using System;
using System.Linq;
using System.Threading.Tasks;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Contracts.Repository;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Command.DataImporter
{
    public class ProcessDataImportEventHandler: ICommandHandler<ProcessDataImportEventCommand>
    {
        private readonly IDataImporterRepository _repo;

        public ProcessDataImportEventHandler(IDataImporterRepository repo)
        {
            _repo = repo;
        }

        public void Execute(ProcessDataImportEventCommand command)
        {
            DataImportEvent @event = DataImportEvent.Create(command.DataSourceId, command.FileName);
            @event.EventId = _repo.Save(@event);

            Parallel.ForEach(command.Data.Cast<IDataRecord>(), (record) =>
            {
                string json = record.GetJSON();
                string keyHash = record.GetKeyHash();
                string dataHash = record.GetDataHash();

                DataImportEventRow row = _repo.GetDataImportEventRow(command.DataSourceId, keyHash) ?? new DataImportEventRow
                {
                    DataSourceId = command.DataSourceId,
                    JSON = json,
                    KeyHash = keyHash
                };

                // Data has changed since last import. Audit and update.
                if (row.DataHash != dataHash)
                {
                    DataImportEventAudit audit = DataImportEventAudit.Create(row.EventId, row.DataSourceId, row.JSON, row.DataHash, row.KeyHash);
                    _repo.Save(audit);

                    row.DataHash = dataHash;
                    row.LastUpdated = DateTime.UtcNow;
                    row.EventId = @event.EventId;
                    row.JSON = json;

                    _repo.Save(row);
                }
            });
        }
    }
}
