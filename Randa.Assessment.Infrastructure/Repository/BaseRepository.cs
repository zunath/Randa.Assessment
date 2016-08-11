using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using Dapper;
using Randa.Assessment.Infrastructure.Helpers.Contracts;

namespace Randa.Assessment.Infrastructure.Repository
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;
        private readonly ISQLHelper _sqlHelper;

        protected BaseRepository(string connectionString, ISQLHelper sqlHelper)
        {
            _connectionString = connectionString;
            _sqlHelper = sqlHelper;
        }

        private T WithConnection<T>(Func<IDbConnection, T> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open(); 
                    return getData(connection); 
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    $"{GetType().FullName}.WithConnection() experienced a SQL exception (not a timeout)", ex);
            }
        }

        protected IEnumerable<T> StoredProcedureMany<T>(string procName, params SqlParameter[] parameters)
        {
            return WithConnection(
                c => c.Query<T>(procName, ParametersToExpando(parameters), commandType: CommandType.StoredProcedure)
            );
        }

        protected T StoredProcedureSingle<T>(string procName, params SqlParameter[] parameters)
        {
            return WithConnection(
                c => c.Query<T>(procName, ParametersToExpando(parameters), commandType: CommandType.StoredProcedure).SingleOrDefault()
            );
        }

        protected IEnumerable<T> AdHocSQLMany<T>(string sql, params SqlParameter[] parameters)
        {
            return WithConnection(
                c => c.Query<T>(sql, ParametersToExpando(parameters))
            );
        }

        protected T AdHocSQLSingle<T>(string sql, params SqlParameter[] parameters)
        {
            return WithConnection(
                c => c.Query<T>(sql, ParametersToExpando(parameters)).SingleOrDefault()
            );
        }

        protected int SaveEntity<T>(T entity, string columnName, string tableName=null, bool isIdentity = true)
            where T: class
        {
            return WithConnection(c =>
            {
                string sql = _sqlHelper.CreateSaveString(entity, columnName, tableName, isIdentity);
                return isIdentity ? Convert.ToInt32(c.Query<int>(sql).Single()) : c.Execute(sql);
            });
        }


        private static IDictionary<string, object> ParametersToExpando(params SqlParameter[] parameters)
        {
            var param = new ExpandoObject() as IDictionary<string, object>;
            foreach (var parameter in parameters)
            {
                param.Add(parameter.ParameterName, parameter.Value);
            }

            return param;
        }

    }
}
