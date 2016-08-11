namespace Randa.Assessment.Infrastructure.Helpers.Contracts
{
    public interface ISQLHelper
    {
        string CreateSaveString<T>(string idField, T entity) where T : class;
        string CreateSaveString<T>(string tableName, string idField, T entity) where T : class;
    }
}
