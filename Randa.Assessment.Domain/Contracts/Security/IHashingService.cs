using System.Text;

namespace Randa.Assessment.Domain.Contracts.Security
{
    public interface IHashingService
    {
        string HashToString(string inputString, Encoding encoding);
    }
}
