using System;

namespace Randa.Assessment.Domain.DataImporter
{
    public class DataImportEventRow
    {
        public int EventRowId { get; set; }
        public string SourceId { get; set; }
        public string KeyHash { get; set; }
        public string JSON { get; set; }
        public string DataHash { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
