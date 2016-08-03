using System;

namespace Randa.Assessment.Domain.DataImporter
{
    public class DataImportEvent
    {
        public int EventId { get; set; }
        public DateTime ImportDate { get; set; }
        public string FileName { get; set; }
        public string SourceId { get; set; }
    }
}
