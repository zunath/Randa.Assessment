using System.Collections.Generic;
using System.IO;
using System.Linq;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Services.Contracts.DataImporter;

namespace Randa.Assessment.Infrastructure.FileParsers
{
    public class EISDataFileParser: IDataImportParser<EISDataRecord>
    {
        public IEnumerable<EISDataRecord> ParseFile(string filePath)
        {
            List<EISDataRecord> records = new List<EISDataRecord>();
            string[] lines = File.ReadAllLines(filePath).Skip(1).ToArray();

            foreach (string line in lines)
            {
                string[] data = line.Split('\t');

                EISDataRecord record = new EISDataRecord();
                record.TestAdminCode = data[0];
                record.DistrictID = data[1];
                record.SchoolID = data[2];
                record.Grade = data[3];
                record.LastName = data[4];
                record.FirstName = data[5];

                records.Add(record);
            }

            return records;
        }
    }
}
