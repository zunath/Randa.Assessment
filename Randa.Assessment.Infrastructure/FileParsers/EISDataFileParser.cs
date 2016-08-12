using System;
using System.Collections;
using System.IO;
using System.Linq;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.DataImporter.DataRecords;

namespace Randa.Assessment.Infrastructure.FileParsers
{
    public class EISDataFileParser: IDataImportParser
    {
        public IEnumerable ParseFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath).Skip(1).ToArray();

            foreach (string line in lines)
            {
                string[] data = line.Split('\t');

                yield return new EISDataRecord
                {
                    TestAdminCode = data[0],
                    DistrictID = data[2],
                    SchoolID = data[3],
                    Grade = data[4],
                    LastName = data[5],
                    FirstName = data[6],
                    MiddleInitial = data[7],
                    USID = data[8],
                    DateOfBirth = data[9],
                    EthnicOrigin = data[10],
                    IsRaceIndian = data[11] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[11])),
                    IsRaceAsian = data[12] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[12])),
                    IsRaceBlack = data[13] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[13])),
                    IsRacePacificIslander = data[14] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[14])),
                    IsRaceWhite = data[15] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[15])),
                    IsRaceUnspecified = data[16] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[16])),
                    Gender = data[17],
                    CodeAB = data[18]
                };
            }
        }
    }
}
