namespace Randa.Assessment.Domain.Contracts.DataImporter
{
    public interface IDataRecord
    {
        string GetKeyHash();
        string GetDataHash();
        string GetJSON();
    }
}
