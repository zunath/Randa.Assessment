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
        public DateTime DateLastUpdated { get; private set; }
        public DateTime? DateProcessed { get; private set; }

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
                DateLastUpdated = DateTime.UtcNow,
                KeyHash = keyHash,
                JSON = json,
                DateProcessed = null
            };
        }
    }
}
