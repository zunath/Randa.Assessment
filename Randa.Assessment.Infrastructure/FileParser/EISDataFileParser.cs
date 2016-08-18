using System;
using System.Collections;
using System.IO;
using System.Linq;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.DataRecord;

namespace Randa.Assessment.Infrastructure.FileParser
{
    public class EISDataFileParser: IDataImportParser
    {
        public IEnumerable ParseFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath).Skip(1).ToArray();

            foreach (string line in lines)
            {
                string[] data = line.Split('\t');
                DateTime dob;
                DateTime.TryParse(data[8], out dob);

                yield return new EISDataRecord
                {
                    TestAdminCode = data[0],
                    DistrictId = data[1],
                    SchoolId = data[2],
                    Grade = data[3],
                    LastName = data[4],
                    FirstName = data[5],
                    MiddleInitial = data[6],
                    USID = data[7],
                    DateOfBirth = dob == default(DateTime) ? new DateTime?() : dob,
                    EthnicOrigin = data[9],
                    IsRaceIndian = data[10] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[10])),
                    IsRaceAsian = data[11] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[11])),
                    IsRaceBlack = data[12] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[12])),
                    IsRacePacificIslander = data[13] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[13])),
                    IsRaceWhite = data[14] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[14])),
                    IsRaceUnspecified = data[15] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[15])),
                    Gender = data[16],
                    CodeAB = data[17]
                };
            }
        }
    }
}
