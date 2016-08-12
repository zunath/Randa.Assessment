using System.Security.Cryptography;
using System.Text;
using Randa.Assessment.Domain.Contracts.Security;

namespace Randa.Assessment.Application.Services
{
    public class HashingService: IHashingService
    {
        public string HashToString(string inputString, Encoding encoding)
        {
            var hash = SHA256.Create().ComputeHash(encoding.GetBytes(inputString));
            string returnValue = string.Empty;

            foreach (byte b in hash)
            {
                returnValue += b.ToString("x2");
            }

            return returnValue;
        }
    }
}
