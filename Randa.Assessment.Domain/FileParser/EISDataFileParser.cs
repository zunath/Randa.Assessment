using System;
using System.Collections;
using System.IO;
using System.Linq;
using Randa.Assessment.Domain.Constants;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.DataRecord;

namespace Randa.Assessment.Domain.FileParser
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
                    DistrictId = data[1],
                    SchoolId = data[2],
                    Grade = GetGrade(data[3]),
                    LastName = data[4],
                    FirstName = data[5],
                    MiddleInitial = data[6].First(),
                    USID = data[7],
                    DateOfBirth = GetDateOfBirth(data[8]),
                    EthnicOrigin = GetEthnicityType(data[9]),
                    IsRaceIndian = data[10] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[10])),
                    IsRaceAsian = data[11] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[11])),
                    IsRaceBlack = data[12] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[12])),
                    IsRacePacificIslander = data[13] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[13])),
                    IsRaceWhite = data[14] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[14])),
                    IsRaceUnspecified = data[15] != string.Empty && Convert.ToBoolean(Convert.ToInt16(data[15])),
                    Gender = GetGenderType(data[16]),
                    CodeAB = GetCodeAB(data[17])
                };
            }
        }

        private static Ethnicity GetEthnicityType(string data)
        {
            switch (data)
            {
                case "H":
                    return Ethnicity.Hispanic;
                case "N":
                    return Ethnicity.NonHispanic;
                default:
                    return Ethnicity.Unknown;
            }
        }

        private static DateTime? GetDateOfBirth(string data)
        {
            DateTime dob;
            DateTime.TryParse(data, out dob);
            return dob == default(DateTime) ? new DateTime?() : dob;
        }

        private static Gender GetGenderType(string data)
        {
            switch (data)
            {
                case "M": return Gender.Male;
                case "F": return Gender.Female;
                default: return Gender.Unknown;
            }
        }

        private static CodeAB GetCodeAB(string data)
        {
            switch (data)
            {
                case "A": return CodeAB.A;
                case "B": return CodeAB.B;
                default: return CodeAB.B;
            }
        }

        private static Grade GetGrade(string data)
        {
            switch (data)
            {
                case "0": return Grade.Kindergarten;
                case "1": return Grade.First;
                case "2": return Grade.Second;
                case "3": return Grade.Third;
                case "4": return Grade.Fourth;
                case "5": return Grade.Fifth;
                case "6": return Grade.Sixth;
                case "7":
                case "P7":
                    return Grade.Seventh;
                case "8": return Grade.Eighth;
                case "9": return Grade.Ninth;
                case "10": return Grade.Tenth;
                case "11": return Grade.Eleventh;
                case "12": return Grade.Twelfth;
                case "13": return Grade.PostTwelve;
                default: return Grade.Unknown;
            }
        }
    }
}
