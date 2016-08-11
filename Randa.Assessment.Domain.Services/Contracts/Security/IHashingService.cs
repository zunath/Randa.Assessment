using System.Text;

namespace Randa.Assessment.Domain.Services.Contracts.Security
{
    public interface IHashingService
    {
        string HashToString(string inputString, Encoding encoding);
    }
}
