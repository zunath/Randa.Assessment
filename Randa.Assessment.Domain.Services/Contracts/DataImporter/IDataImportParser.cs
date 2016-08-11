using System.Collections;

namespace Randa.Assessment.Domain.Services.Contracts.DataImporter
{
    public interface IDataImportParser
    {
        IEnumerable ParseFile (string filePath);
    }
}
