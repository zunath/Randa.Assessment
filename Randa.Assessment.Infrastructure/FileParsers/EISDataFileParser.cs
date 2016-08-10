using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Randa.Assessment.Domain.DataImporter.DataRecords;
using Randa.Assessment.Domain.Services.Contracts.DataImporter;

namespace Randa.Assessment.Infrastructure.FileParsers
{
    public class EISDataFileParser: IDataImportParser
    {
        public IEnumerable ParseFile(string filePath)
        {
            List<EISDataRecord> records = new List<EISDataRecord>();
            string[] lines = File.ReadAllLines(filePath).Skip(1).ToArray();

            foreach (string line in lines)
            {
                string[] data = line.Split('\t');

                EISDataRecord record = new EISDataRecord
                {
                    TestAdminCode = data[0],
                    DistrictID = data[1],
                    SchoolID = data[2],
                    Grade = data[3],
                    LastName = data[4],
                    FirstName = data[5],
                    MiddleInitial = data[6],
                    USID = data[7],
                    DateOfBirth = data[8],
                    EthnicOrigin = data[9],
                    IsRaceIndian = Convert.ToBoolean(Convert.ToInt16(data[10])),
                    IsRaceAsian = Convert.ToBoolean(Convert.ToInt16(data[11])),
                    IsRaceBlack = Convert.ToBoolean(Convert.ToInt16(data[12])),
                    IsRacePacificIslander = Convert.ToBoolean(Convert.ToInt16(data[13])),
                    IsRaceWhite = Convert.ToBoolean(Convert.ToInt16(data[14])),
                    IsRaceUnspecified = Convert.ToBoolean(Convert.ToInt16(data[15])),
                    Gender = data[16],
                    CodeAB = data[17]
                };

                records.Add(record);
            }

            return records;
        }
    }
}
