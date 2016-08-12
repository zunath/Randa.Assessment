using System;

namespace Randa.Assessment.Domain.DataImporter
{
    public class DataImportEvent
    {
        public int EventId { get; set; }
        public DateTime ImportDate { get; private set; }
        public string FileName { get; private set; }
        public string DataSourceId { get; private set; }

        public static DataImportEvent Create(
            string dataSourceId,
            string fileName)
        {
            return new DataImportEvent
            {
                DataSourceId = dataSourceId,
                FileName = fileName,
                ImportDate = DateTime.UtcNow
            };
        }


    }
}
