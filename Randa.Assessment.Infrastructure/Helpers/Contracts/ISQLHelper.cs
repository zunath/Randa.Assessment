﻿namespace Randa.Assessment.Infrastructure.Helpers.Contracts
{
    public interface ISQLHelper
    {
        string CreateSaveString<T>(T entity, string columnName, string tableName = null) where T : class;
    }
}