using System;

namespace Randa.Assessment.Domain.DataImporter
{
    public class DataImportEventRow
    {
        public string KeyHash { get; set; }
        public int EventId { get; set; }
        public string DataSourceId { get; set; }
        public string JSON { get; set; }
        public string DataHash { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime? ProcessedDate { get; set; }
    }
}
