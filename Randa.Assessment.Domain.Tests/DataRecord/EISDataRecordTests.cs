using System;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randa.Assessment.Domain.Constants;
using Randa.Assessment.Domain.DataRecord;

namespace Randa.Assessment.Domain.Tests.DataRecord
{
    [TestClass]
    public class EISDataRecordTests
    {
        private const string InvalidCharacters = "!@#$%^&*()-_=+/?;:'\"~`.>,< }{][|\\1234567890";

        private EISDataRecord BuildRecord()
        {
            return new EISDataRecord
            {
                DistrictId = "66666",
                FirstName = "First Name",
                LastName = "Last Name",
                SchoolId = "6666",
                TestAdminCode = "2015-2016",
                Grade = Grade.Eighth,
                CodeAB = CodeAB.A,
                DateOfBirth = new DateTime(1990, 1, 5),
                EthnicOrigin = Ethnicity.Hispanic,
                Gender = Gender.Male,
                IsRaceAsian = true,
                IsRaceBlack = true,
                IsRaceIndian = true,
                IsRacePacificIslander = true,
                IsRaceUnspecified = false,
                IsRaceWhite = true,
                MiddleInitial = 'M',
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

            Assert.AreEqual(hash, "fbdc0f85f38f1d8a0b922db613e08d8e0613befb7b25b1bd4f4c43e1e0f3bb76");
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

            Assert.AreEqual(json, "{\"TestAdminCode\":\"2015-2016\",\"DistrictId\":\"66666\",\"SchoolId\":\"6666\",\"Grade\":8,\"LastName\":\"Last Name\",\"FirstName\":\"First Name\",\"MiddleInitial\":\"M\",\"USID\":\"000000000\",\"DateOfBirth\":\"1990-01-05T00:00:00\",\"EthnicOrigin\":2,\"IsRaceIndian\":true,\"IsRaceAsian\":true,\"IsRaceBlack\":true,\"IsRacePacificIslander\":true,\"IsRaceWhite\":true,\"IsRaceUnspecified\":false,\"Gender\":1,\"CodeAB\":1}");
        }

        [TestMethod]
        public void EISDataRecord_GetJSON_ShouldNotMatch()
        {
            EISDataRecord record = BuildRecord();
            record.LastName = "ChangedLastName";
            string json = record.GetJSON();

            Assert.AreNotEqual(json, "{\"TestAdminCode\":\"2015-2016\",\"DistrictID\":\"66666\",\"SchoolID\":\"6666\",\"Grade\":\"8\",\"LastName\":\"Last Name\",\"FirstName\":\"First Name\",\"MiddleInitial\":\"M\",\"USID\":\"000000000\",\"DateOfBirth\":\"1990-01-05\",\"EthnicOrigin\":\"H\",\"IsRaceIndian\":true,\"IsRaceAsian\":true,\"IsRaceBlack\":true,\"IsRacePacificIslander\":true,\"IsRaceWhite\":true,\"IsRaceUnspecified\":false,\"Gender\":\"M\",\"CodeAB\":\"A\"}");
        }

        [TestMethod]
        public void EISDataRecord_CleanDistrictId_ShouldBePaddedWithZeros()
        {
            EISDataRecord record = BuildRecord();
            record.DistrictId = "1";
            record.CleanDistrictId();

            Assert.AreEqual(record.DistrictId, "00001");
        }

        [TestMethod]
        public void EISDataRecord_CleanSchoolId_ShouldBePaddedWithZeros()
        {
            EISDataRecord record = BuildRecord();
            record.SchoolId = "1";
            record.CleanSchoolId();

            Assert.AreEqual(record.SchoolId, "0001");
        }

        [TestMethod]
        public void EISDataRecord_CleanUSID_ShouldBePaddedWithZeros()
        {
            EISDataRecord record = BuildRecord();
            record.USID = "1";
            record.CleanUSID();

            Assert.AreEqual(record.USID, "000000001");
        }

        [TestMethod]
        public void EISDataRecord_CleanUSID_ShouldBeNumericOnly()
        {
            EISDataRecord record = BuildRecord();
            record.USID = InvalidCharacters;
            record.CleanUSID();

            Assert.AreEqual(record.USID, "1234567890");
        }

        [TestMethod]
        public void EISDataRecord_CleanFirstName_ShouldBeNoSpecialCharactersOrNumbers()
        {
            EISDataRecord record = BuildRecord();
            record.FirstName = InvalidCharacters;
            record.CleanFirstName();

            Assert.AreEqual(record.FirstName, string.Empty);
        }
        [TestMethod]
        public void EISDataRecord_CleanFirstName_ShouldMatch()
        {
            EISDataRecord record = BuildRecord();
            record.FirstName = "T1y\\L()E!R";
            record.CleanFirstName();

            Assert.AreEqual(record.FirstName, "TYLER");
        }

        [TestMethod]
        public void EISDataRecord_CleanLastName_ShouldBeNoSpecialCharactersOrNumbers()
        {
            EISDataRecord record = BuildRecord();
            record.LastName = InvalidCharacters;
            record.CleanLastName();

            Assert.AreEqual(record.LastName, string.Empty);
        }

        [TestMethod]
        public void EISDataRecord_CleanLastName_ShouldMatch()
        {
            EISDataRecord record = BuildRecord();
            record.LastName = "T1y\\L()E!R";
            record.CleanLastName();

            Assert.AreEqual(record.LastName, "TYLER");
        }

        [TestMethod]
        public void EISDataRecord_CleanMiddleInitial_ShouldBeNoSpecialCharactersOrNumbers()
        {
            EISDataRecord record = BuildRecord();

            foreach (char c in InvalidCharacters)
            {
                record.MiddleInitial = c;
                record.CleanMiddleInitial();

                Assert.AreEqual(record.MiddleInitial, '\0');
            }
        }
    }
}
