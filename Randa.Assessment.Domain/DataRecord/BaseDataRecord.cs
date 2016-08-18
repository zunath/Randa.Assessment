using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Randa.Assessment.Domain.Contracts.DataImporter;

namespace Randa.Assessment.Domain.DataRecord
{
    public abstract class BaseDataRecord: IDataRecord
    {
        protected string GetHash(params string[] values)
        {
            string inputString = values.Aggregate(string.Empty, (current, value) => current + value);
            var hash = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(inputString));
            return hash.Aggregate(string.Empty, (current, b) => current + b.ToString("x2"));
        }

        public abstract string GetKeyHash();

        public virtual string GetDataHash()
        {
            return GetHash(GetJSON());
        }

        public virtual string GetJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        protected string RemoveSpecialCharactersAndNumbers(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z]+", "", RegexOptions.Compiled);
        }

        protected string RemoveNonNumbers(string str)
        {
            return Regex.Replace(str, @"[^\d]", "", RegexOptions.Compiled);
        }
    }
}
