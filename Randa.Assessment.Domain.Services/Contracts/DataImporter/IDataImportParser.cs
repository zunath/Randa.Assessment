
using System.Collections.Generic;

namespace Randa.Assessment.Domain.Services.Contracts.DataImporter
{
    public interface IDataImportParser<T>
    {
        IEnumerable<T> ParseFile (string filePath);
    }
}
