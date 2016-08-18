using System;
using System.Text.RegularExpressions;

namespace Randa.Assessment.Domain.DataRecord
{
    public class EISDataRecord: BaseDataRecord
    {
        public string TestAdminCode { get; set; }
        public string DistrictId { get; set; }
        public string SchoolId { get; set; }
        public string Grade { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string USID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EthnicOrigin { get; set; }
        public bool IsRaceIndian { get; set; }
        public bool IsRaceAsian { get; set; }
        public bool IsRaceBlack { get; set; }
        public bool IsRacePacificIslander { get; set; }
        public bool IsRaceWhite { get; set; }
        public bool IsRaceUnspecified { get; set; }
        public string Gender { get; set; }
        public string CodeAB { get; set; }

        // TODO: Add more fields

        private string RemoveSpecialCharactersAndNumbers(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z]+", "", RegexOptions.Compiled);
        }

        public override string GetKeyHash()
        {
            return GetHash(TestAdminCode, DistrictId, SchoolId, USID);
        }

        public void CleanDistrictId()
        {
            DistrictId = DistrictId.PadLeft(5, '0');
        }

        public void CleanSchoolId()
        {
            SchoolId = SchoolId.PadLeft(4, '0');
        }

        public void CleanUSID()
        {
            USID = USID.PadLeft(9, '0');
        }

        public void CleanFirstName()
        {
            FirstName = RemoveSpecialCharactersAndNumbers(FirstName);
        }

        public void CleanLastName()
        {
            LastName = RemoveSpecialCharactersAndNumbers(LastName);
        }
    }
}
