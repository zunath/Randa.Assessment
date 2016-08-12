using System.Collections;

namespace Randa.Assessment.Domain.Contracts.DataImporter
{
    public interface IDataImportParser
    {
        IEnumerable ParseFile (string filePath);
    }
}
