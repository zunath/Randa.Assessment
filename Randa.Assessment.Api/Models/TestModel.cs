
using System.ComponentModel.DataAnnotations;

namespace Randa.Assessment.Api.Models
{
    public class TestModel
    {
        [Key]
        public string Value { get; set; }

        public TestModel(string value)
        {
            Value = value;
        }

        public TestModel() { }
    }
}