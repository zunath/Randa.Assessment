using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Randa.Assessment.Domain.Contracts.Entities;
using Randa.Assessment.Domain.Entity;
using Randa.Assessment.Domain.Validators;

namespace Randa.Assessment.Domain.Tests.Entities
{
    [TestClass]
    public class AcademicYearTests
    {
        private readonly IValidatorFactory _validatorFactory;

        public AcademicYearTests()
        {
            var mockFactory = new Mock<IValidatorFactory>();
            mockFactory.Setup(x => x.GetValidator(typeof(AcademicYear))).Returns(new AcademicYearValidator());
            _validatorFactory = mockFactory.Object;
        }

        private AcademicYear BuildRecord()
        {
            return new AcademicYear(0, _validatorFactory)
            {
                DateStart = new DateTime(2015, 1, 1),
                DateEnd = new DateTime(2016, 1, 1),
                Name = "2015-2016",
                AcademicYearId = 2015
            };
        }

        [TestMethod]
        public void AcademicYear_ShouldBeValid()
        {
            Assert.IsTrue(BuildRecord().IsValid());
        }

        [TestMethod]
        public void AcademicYear_EmptyName_ShouldBeInvalid()
        {
            var record = BuildRecord();
            record.Name = string.Empty;

            Assert.IsFalse(record.IsValid());
        }

        [TestMethod]
        public void AcademicYear_StartDateAfterEndDate_ShouldBeInvalid()
        {
            var record = BuildRecord();
            record.DateStart = new DateTime(2015, 1, 1);
            record.DateEnd = new DateTime(2014, 1, 1);

            Assert.IsFalse(record.IsValid());
        }

        [TestMethod]
        public void AcademicYear_StartAndEndDatesSame_ShouldBeInvalid()
        {
            var record = BuildRecord();
            record.DateEnd = record.DateStart;

            Assert.IsFalse(record.IsValid());
        }

        [TestMethod]
        public void AcademicYear_NullName_ShouldBeInvalid()
        {
            var record = BuildRecord();
            record.Name = null;

            Assert.IsFalse(record.IsValid());
        }
    }
}
