namespace Randa.Assessment.Domain.DataImporter.DataRecords
{
    public class EISDataRecord: BaseDataRecord
    {
        public string TestAdminCode { get; set; }
        public string DistrictID { get; set; }
        public string SchoolID { get; set; }
        public string Grade { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string USID { get; set; }
        public string DateOfBirth { get; set; }
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


        public override string GetKeyHash()
        {
            return GetHash(TestAdminCode, DistrictID, SchoolID, USID);
        }
        
    }
}
