using System;
using System.Text.RegularExpressions;
using Randa.Assessment.Domain.Constants;

namespace Randa.Assessment.Domain.DataRecord
{
    public class EISDataRecord: BaseDataRecord
    {
        public string TestAdminCode { get; set; }
        public string DistrictId { get; set; }
        public string SchoolId { get; set; }
        public Grade Grade { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public char MiddleInitial { get; set; }
        public string USID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Ethnicity EthnicOrigin { get; set; }
        public bool IsRaceIndian { get; set; }
        public bool IsRaceAsian { get; set; }
        public bool IsRaceBlack { get; set; }
        public bool IsRacePacificIslander { get; set; }
        public bool IsRaceWhite { get; set; }
        public bool IsRaceUnspecified { get; set; }
        public Gender Gender { get; set; }
        public CodeAB CodeAB { get; set; }

        // TODO: Add more fields


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
            USID = RemoveNonNumbers(USID);
        }

        public void CleanFirstName()
        {
            FirstName = RemoveSpecialCharactersAndNumbers(FirstName);
            FirstName = FirstName.ToUpper();
        }

        public void CleanLastName()
        {
            LastName = RemoveSpecialCharactersAndNumbers(LastName);
            LastName = LastName.ToUpper();
        }

        public void CleanMiddleInitial()
        {
            string middleInitial = Convert.ToString(MiddleInitial);
            middleInitial = RemoveSpecialCharactersAndNumbers(middleInitial);
            middleInitial = middleInitial.ToUpper();
            MiddleInitial = middleInitial.Length == 0 ? '\0' : Convert.ToChar(middleInitial);
        }
    }
}
