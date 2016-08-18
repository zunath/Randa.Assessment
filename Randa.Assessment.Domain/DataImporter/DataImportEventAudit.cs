using System;

namespace Randa.Assessment.Domain.DataImporter
{
    public class DataImportEventAudit
    {
        public int EventAuditId { get; set; }
        public int EventId { get; private set; }
        public string DataSourceId { get; private set; }
        public string JSON { get; private set; }
        public string DataHash { get; private set; }
        public string KeyHash { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public DateTime? ProcessedDate { get; private set; }

        public static DataImportEventAudit Create(
            int eventId,
            string dataSourceId,
            string json,
            string dataHash,
            string keyHash)
        {
            return new DataImportEventAudit
            {
                DataSourceId = dataSourceId,
                EventId = eventId,
                DataHash = dataHash,
                LastUpdated = DateTime.UtcNow,
                KeyHash = keyHash,
                JSON = json,
                ProcessedDate = null
            };
        }
    }
}
