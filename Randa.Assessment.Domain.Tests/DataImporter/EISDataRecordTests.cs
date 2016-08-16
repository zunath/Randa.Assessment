using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randa.Assessment.Domain.DataImporter.DataRecords;

namespace Randa.Assessment.Domain.Tests.DataImporter
{
    [TestClass]
    public class EISDataRecordTests
    {
        private EISDataRecord BuildRecord()
        {
            return new EISDataRecord
            {
                DistrictID = "66666",
                FirstName = "First Name",
                LastName = "Last Name",
                SchoolID = "6666",
                TestAdminCode = "2015-2016",
                Grade = "8",
                CodeAB = "A",
                DateOfBirth = "1990-01-05",
                EthnicOrigin = "H",
                Gender = "M",
                IsRaceAsian = true,
                IsRaceBlack = true,
                IsRaceIndian = true,
                IsRacePacificIslander = true,
                IsRaceUnspecified = false,
                IsRaceWhite = true,
                MiddleInitial = "M",
                USID = "000000000"
            };
        }

        [TestMethod]
        public void EISDataRecord_GetKeyHash_ShouldMatch()
        {
            EISDataRecord record = BuildRecord();
            string hash = record.GetKeyHash();

            Assert.AreEqual(hash, "ca3aab9f380a504abec24a05edfec496c6c84f6778fcc503946584ec31573e7a");
        }

        [TestMethod]
        public void EISDataRecord_GetKeyHash_ShouldNotMatch()
        {
            EISDataRecord record = BuildRecord();
            record.USID = "999999999";
            string hash = record.GetKeyHash();

            Assert.AreNotEqual(hash, "ca3aab9f380a504abec24a05edfec496c6c84f6778fcc503946584ec31573e7a");
        }

        [TestMethod]
        public void EISDataRecord_GetDataHash_ShouldMatch()
        {
            EISDataRecord record = BuildRecord();
            string hash = record.GetDataHash();

            Assert.AreEqual(hash, "63f34ae234eeeb859c3194665a5e37f8980deb476b8e6fc2fb9a13b2c331721a");
        }

        [TestMethod]
        public void EISDataRecord_GetDataHash_ShouldNotMatch()
        {
            EISDataRecord record = BuildRecord();
            record.FirstName = "NewFirstName";
            string hash = record.GetDataHash();

            Assert.AreNotEqual(hash, "63f34ae234eeeb859c3194665a5e37f8980deb476b8e6fc2fb9a13b2c331721a");
        }

        [TestMethod]
        public void EISDataRecord_GetJSON_ShouldMatch()
        {
            EISDataRecord record = BuildRecord();
            string json = record.GetJSON();

            Assert.AreEqual(json, "{\"TestAdminCode\":\"2015-2016\",\"DistrictID\":\"66666\",\"SchoolID\":\"6666\",\"Grade\":\"8\",\"LastName\":\"Last Name\",\"FirstName\":\"First Name\",\"MiddleInitial\":\"M\",\"USID\":\"000000000\",\"DateOfBirth\":\"1990-01-05\",\"EthnicOrigin\":\"H\",\"IsRaceIndian\":true,\"IsRaceAsian\":true,\"IsRaceBlack\":true,\"IsRacePacificIslander\":true,\"IsRaceWhite\":true,\"IsRaceUnspecified\":false,\"Gender\":\"M\",\"CodeAB\":\"A\"}");
        }

        [TestMethod]
        public void EISDataRecord_GetJSON_ShouldNotMatch()
        {
            EISDataRecord record = BuildRecord();
            record.LastName = "ChangedLastName";
            string json = record.GetJSON();

            Assert.AreNotEqual(json, "{\"TestAdminCode\":\"2015-2016\",\"DistrictID\":\"66666\",\"SchoolID\":\"6666\",\"Grade\":\"8\",\"LastName\":\"Last Name\",\"FirstName\":\"First Name\",\"MiddleInitial\":\"M\",\"USID\":\"000000000\",\"DateOfBirth\":\"1990-01-05\",\"EthnicOrigin\":\"H\",\"IsRaceIndian\":true,\"IsRaceAsian\":true,\"IsRaceBlack\":true,\"IsRacePacificIslander\":true,\"IsRaceWhite\":true,\"IsRaceUnspecified\":false,\"Gender\":\"M\",\"CodeAB\":\"A\"}");
        }
    }
}
