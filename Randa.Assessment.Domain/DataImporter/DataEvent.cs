using System;

namespace Randa.Assessment.Domain.DataImporter
{
    public class DataEvent
    {
        public int EventId { get; set; }
        public DateTime ImportDate { get; set; }
        public string FileName { get; set; }
        public string SourceId { get; set; }
    }
}
