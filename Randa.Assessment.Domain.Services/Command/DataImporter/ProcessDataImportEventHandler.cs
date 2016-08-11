using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Domain.Services.Contracts.Security;

namespace Randa.Assessment.Domain.Services.Command.DataImporter
{
    public class ProcessDataImportEventHandler: ICommandHandler<ProcessDataImportEventCommand>
    {
        private readonly IDataImporterRepository _repo;
        private readonly IHashingService _hashingService;

        public ProcessDataImportEventHandler(IDataImporterRepository repo, IHashingService hashingService)
        {
            _repo = repo;
            _hashingService = hashingService;
        }

        public void Execute(ProcessDataImportEventCommand command)
        {
            List<DataImportSourceKey> keys = _repo.GetDataSourceKeys(command.DataSourceId).ToList();
            if (keys.Count <= 0) throw new Exception("No keys configured for this import event type.");

            DataImportEvent @event = new DataImportEvent
            {
                DataSourceId = command.DataSourceId,
                FileName = command.FileName,
                ImportDate = DateTime.UtcNow
            };

            int eventId = _repo.Save(@event);
            
            foreach (var record in command.Data)
            {
                string combinedKey = string.Empty;
                string json = JsonConvert.SerializeObject(record);

                foreach (var key in keys)
                {
                    // Get the value of the key by property name
                    string keyData = Convert.ToString(record.GetType().GetProperty(key.Key).GetValue(record, null));
                    combinedKey += keyData;
                }

                string keyHash = _hashingService.HashToString(combinedKey, Encoding.ASCII);
                string dataHash = _hashingService.HashToString(json, Encoding.ASCII);

                DataImportEventRow row = _repo.GetDataImportEventRow(command.DataSourceId, keyHash) ?? new DataImportEventRow
                {
                    DataSourceId = command.DataSourceId,
                    JSON = json,
                    KeyHash = keyHash
                };

                // Data has changed since last import. Audit and update.
                if (row.DataHash != dataHash)
                {
                    DataImportEventAudit audit = new DataImportEventAudit
                    {
                        DataSourceId = row.DataSourceId,
                        EventId = row.EventId,
                        DataHash = row.DataHash,
                        LastUpdated = row.LastUpdated,
                        JSON = row.JSON,
                        KeyHash = row.KeyHash
                    };

                    _repo.Save(audit);

                    row.DataHash = dataHash;
                    row.LastUpdated = DateTime.UtcNow;
                    row.EventId = eventId;
                    row.JSON = json;

                    _repo.Save(row);
                }


            }
        }
    }
}
