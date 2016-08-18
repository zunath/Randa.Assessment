namespace Randa.Assessment.Infrastructure.Helper.Contracts
{
    public interface ISQLHelper
    {
        string CreateSaveString<T>(T entity, string columnName, string tableName = null, bool hasIdentity = true) where T : class;
    }
}
