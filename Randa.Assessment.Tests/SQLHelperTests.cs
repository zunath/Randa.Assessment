using System;
using Microsoft.SqlServer.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Randa.Assessment.Infrastructure.Helpers;

namespace Randa.Assessment.Tests
{
    [TestClass]
    public class SQLHelperTests
    {

        private class TestClass1
        {
            public int IdField { get; set; }
            public string Prop2 { get; set; }

        }

        [TestMethod]
        public void one_field_insert_or_update_test()
        {
            var helper = new SQLHelper();

            var testClass = new TestClass1()
            {
                IdField = 1,
                Prop2 = "Test"
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.IdField));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.TestClass1 WITH (updlock, serializable) WHERE IdField = 1)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.TestClass1" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp2 = 'Test'" + Environment.NewLine +
                        "\tOUTPUT INSERTED.IdField" + Environment.NewLine +
                    "\tWHERE IdField = 1" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.TestClass1 ([Prop2])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.IdField" + Environment.NewLine +
                    "\tVALUES ( 'Test' )" + Environment.NewLine +
                "END" + Environment.NewLine;
            
            Assert.AreEqual(testString, result);
        }

        private class TestClass2
        {
            public int Id { get; set; }
            public string Prop2 { get; set; }
            public float Prop3 { get; set; }

        }

        [TestMethod]
        public void two_field_insert_or_update_test()
        {
            var helper = new SQLHelper();

            var testClass = new TestClass2()
            {
                Id = 2,
                Prop2 = "Test",
                Prop3 = 1.0f
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.TestClass2 WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.TestClass2" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp2 = 'Test'" + Environment.NewLine +
                        ", \t\tProp3 = 1" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.TestClass2 ([Prop2], [Prop3])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 'Test', 1 )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
            Assert.AreEqual(testString, result);
        }

        private class NullableDateTimeClass
        {
            public int Id { get; set; }
            public DateTime? Prop { get; set; }
        }

        [TestMethod]
        public void nullable_datetime_not_null()
        {
            var helper = new SQLHelper();

            var testClass = new NullableDateTimeClass()
            {
                Id = 2,
                Prop = new DateTime(1999, 10, 5, 15, 40, 15)
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.NullableDateTimeClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.NullableDateTimeClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = '10/5/1999 3:40:15 PM'" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.NullableDateTimeClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( '10/5/1999 3:40:15 PM' )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void nullable_datetime_null()
        {
            var helper = new SQLHelper();

            var testClass = new NullableDateTimeClass()
            {
                Id = 2,
                Prop = null
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.NullableDateTimeClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.NullableDateTimeClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = NULL" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.NullableDateTimeClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( NULL )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        private class BooleanClass
        {
            public int Id { get; set; }
            public bool Prop { get; set; }
        }

        [TestMethod]
        public void bool_is_true()
        {
            var helper = new SQLHelper();

            var testClass = new BooleanClass()
            {
                Id = 2,
                Prop = true
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.BooleanClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.BooleanClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 1" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.BooleanClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 1 )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void bool_is_false()
        {
            var helper = new SQLHelper();

            var testClass = new BooleanClass()
            {
                Id = 2,
                Prop = false
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.BooleanClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.BooleanClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 0" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.BooleanClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 0 )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        private class NullableBooleanClass
        {
            public int Id { get; set; }
            public bool? Prop { get; set; }
        }

        [TestMethod]
        public void nullable_bool_is_false()
        {
            var helper = new SQLHelper();

            var testClass = new NullableBooleanClass()
            {
                Id = 2,
                Prop = false
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.NullableBooleanClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.NullableBooleanClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 0" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.NullableBooleanClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 0 )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void nullable_bool_is_true()
        {
            var helper = new SQLHelper();

            var testClass = new NullableBooleanClass()
            {
                Id = 2,
                Prop = true
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.NullableBooleanClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.NullableBooleanClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 1" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.NullableBooleanClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 1 )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void nullable_bool_is_null()
        {
            var helper = new SQLHelper();

            var testClass = new NullableBooleanClass()
            {
                Id = 2,
                Prop = null
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.NullableBooleanClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.NullableBooleanClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = NULL" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.NullableBooleanClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( NULL )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Value cannot be null.\r\nParameter name: idField")]
        public void idField_null_exception()
        {
            var helper = new SQLHelper();

            var testClass = new TestClass2()
            {
                Id = 2,
                Prop2 = "Test",
                Prop3 = 1.0f
            };

            helper.CreateSaveString(testClass, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Value cannot be null.\r\nParameter name: entity")]
        public void entity_null_exception()
        {
            var helper = new SQLHelper();

            helper.CreateSaveString((TestClass2)null, "Id");
        }

        public class DateTimeTestClass
        {
            public int Id { get; set; }
            public DateTime DateTimeTest { get; set; }
        }

        [TestMethod]
        public void date_time_test()
        {
            var helper = new SQLHelper();

            var testClass = new DateTimeTestClass()
            {
                Id = 2,
                DateTimeTest = new DateTime(1999, 10, 5, 15, 40, 15)
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.DateTimeTestClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.DateTimeTestClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tDateTimeTest = '10/5/1999 3:40:15 PM'" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.DateTimeTestClass ([DateTimeTest])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( '10/5/1999 3:40:15 PM' )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        public class StringTestClass
        {
            public int Id { get; set; }
            public string Prop { get; set; }
        }

        [TestMethod]
        public void string_is_not_null()
        {
            var helper = new SQLHelper();

            var testClass = new StringTestClass()
            {
                Id = 2,
                Prop = "Test"
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.StringTestClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.StringTestClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 'Test'" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.StringTestClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 'Test' )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void string_is_null()
        {
            var helper = new SQLHelper();

            var testClass = new StringTestClass()
            {
                Id = 2,
                Prop = null
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.StringTestClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.StringTestClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = ''" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.StringTestClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( '' )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void sql_escape_string()
        {
            var helper = new SQLHelper();

            var testClass = new StringTestClass()
            {
                Id = 2,
                Prop = "Isn't it so that this string's apostrophes should be escaped?"
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.StringTestClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.StringTestClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 'Isn''t it so that this string''s apostrophes should be escaped?'" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.StringTestClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 'Isn''t it so that this string''s apostrophes should be escaped?' )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        public class SqlGeographyTestClass
        {
            public int Id { get; set; }
            public SqlGeography Prop { get; set; }
        }

        [TestMethod]
        public void geography_is_null()
        {
            var helper = new SQLHelper();

            var testClass = new SqlGeographyTestClass()
            {
                Id = 2,
                Prop = null
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.SqlGeographyTestClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.SqlGeographyTestClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = NULL" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.SqlGeographyTestClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( NULL )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void geography_is_not_null()
        {
            var helper = new SQLHelper();

            var testClass = new SqlGeographyTestClass()
            {
                Id = 2,
                Prop = SqlGeography.Point(-86.412172, 36.372854, 4326)
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.SqlGeographyTestClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.SqlGeographyTestClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = geography::Point(-86.412172, 36.372854, 4326)" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.SqlGeographyTestClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( geography::Point(-86.412172, 36.372854, 4326) )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        [TestMethod]
        public void geography_is_empty()
        {
            var helper = new SQLHelper();

            var testClass = new SqlGeographyTestClass()
            {
                Id = 2,
                Prop = new SqlGeography()
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.SqlGeographyTestClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.SqlGeographyTestClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = geography::Point(Null, Null, 4326)" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.SqlGeographyTestClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( geography::Point(Null, Null, 4326) )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }


        public class EnumIntClass
        {
            public int Id { get; set; }
            public TestIntEnum Prop { get; set; }
        }

        public enum TestIntEnum : int
        {
            NumberOne = 1
        }

        [TestMethod]
        public void enum_int_test()
        {
            var helper = new SQLHelper();

            var testClass = new EnumIntClass()
            {
                Id = 2,
                Prop = TestIntEnum.NumberOne
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.EnumIntClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.EnumIntClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 1" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.EnumIntClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 1 )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        public class EnumByteClass
        {
            public int Id { get; set; }
            public TestByteEnum Prop { get; set; }
        }

        public enum TestByteEnum : byte
        {
            NumberOne = 1
        }

        [TestMethod]
        public void enum_byte_test()
        {
            var helper = new SQLHelper();

            var testClass = new EnumByteClass()
            {
                Id = 2,
                Prop = TestByteEnum.NumberOne
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.EnumByteClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.EnumByteClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 1" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.EnumByteClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 1 )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

        public class EnumBasicClass
        {
            public int Id { get; set; }
            public TestBasicEnum Prop { get; set; }
        }

        public enum TestBasicEnum
        {
            NumberOne
        }

        [TestMethod]
        public void enum_basic_test()
        {
            var helper = new SQLHelper();

            var testClass = new EnumBasicClass()
            {
                Id = 2,
                Prop = TestBasicEnum.NumberOne
            };

            var result = helper.CreateSaveString(testClass, nameof(testClass.Id));

            var testString =
                "IF EXISTS (SELECT * FROM dbo.EnumBasicClass WITH (updlock, serializable) WHERE Id = 2)" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tUPDATE dbo.EnumBasicClass" + Environment.NewLine +
                    "\tSET" + Environment.NewLine +
                        "\t\tProp = 0" + Environment.NewLine +
                        "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tWHERE Id = 2" + Environment.NewLine +
                "END" + Environment.NewLine +
                "ELSE" + Environment.NewLine +
                "BEGIN" + Environment.NewLine +
                    "\tINSERT INTO dbo.EnumBasicClass ([Prop])" + Environment.NewLine +
                    "\tOUTPUT INSERTED.Id" + Environment.NewLine +
                    "\tVALUES ( 0 )" + Environment.NewLine +
                "END" + Environment.NewLine;

            Assert.AreEqual(testString, result);
        }

    }
}
