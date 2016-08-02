
namespace Randa.Assessment.Domain.Services.Contracts.DataImporter
{
    public interface IDataImportParser
    {
        T ParseFile<T>(string fileName);
    }
}
