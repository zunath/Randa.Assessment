using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Types;
using Randa.Assessment.Infrastructure.Helpers.Contracts;

namespace Randa.Assessment.Infrastructure.Helpers
{
    public class SQLHelper: ISQLHelper
    {
        /// <summary>
        /// This will take an object that is an object of type class and creates a SQL save string.
        /// The property names of the object should match the columns of the table we want to update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="entity"></param>
        /// <param name="hasIdentity"></param>
        /// <returns>A sql save string</returns>
        public string CreateSaveString<T>(T entity, string columnName, string tableName = null, bool hasIdentity = true) where T : class
        {
            if (tableName == null)
            {
                tableName = typeof(T).Name;
            }

            if (columnName == null)
            {
                throw new ArgumentNullException(nameof(columnName));
            }

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var objValueDict = CreatePropertyValueDictionary(entity);
            var idValue = objValueDict[columnName];
            
            var sb = new StringBuilder();
            sb.AppendLine($"IF EXISTS (SELECT * FROM dbo.{tableName} WITH (updlock, serializable) WHERE {columnName} = {idValue})" +
                            Environment.NewLine + "BEGIN" +
                            Environment.NewLine + $"\tUPDATE dbo.{tableName}" +
                            Environment.NewLine + "\tSET");

            var stringValues =  objValueDict.Where(x => x.Key != columnName).Select(x => $"\t\t{x.Key} = {x.Value}{Environment.NewLine}").ToArray();
            var updates = string.Join(", ", stringValues);

            sb.Append(updates);

            if (hasIdentity)
            {
                sb.AppendLine($"\tOUTPUT INSERTED.{columnName}");
            }

            sb.AppendLine($"\tWHERE {columnName} = {idValue}");

            sb.AppendLine("END");
            sb.AppendLine("ELSE");
            sb.AppendLine("BEGIN");

            sb.Append($"\tINSERT INTO dbo.{tableName} (");

            var fields = hasIdentity ? 
                objValueDict.Where(x => x.Key != columnName).Select(x => $"[{x.Key}]").ToArray() 
                : objValueDict.Select(x => $"[{x.Key}]").ToArray();

            var fieldsConcat = string.Join(", ", fields);

            sb.AppendLine($"{fieldsConcat})");

            if (hasIdentity)
            {
                sb.AppendLine($"\tOUTPUT INSERTED.{columnName}");
            }

            var values = hasIdentity
                ? objValueDict.Where(x => x.Key != columnName).Select(x => $"{x.Value}").ToArray()
                : objValueDict.Select(x => $"{x.Value}").ToArray();
            var valuesConcat = string.Join(", ", values);

            sb.AppendLine($"\tVALUES ( {valuesConcat} )");
            sb.AppendLine("END");

            return sb.ToString();
        }

        /// <summary>
        /// Creates a dictionary of an objects property names and their values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private IDictionary<string, string> CreatePropertyValueDictionary<T>(T entity) where T : class
        {
            var result = new Dictionary<string, string>();
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propName = prop.Name;
                var valueOfProp = prop.GetValue(entity, null);
                if (prop.PropertyType == typeof(string))
                {
                    if (valueOfProp != null)
                    {
                        var stringValue = ((string)valueOfProp).Replace("'", "''");
                        result.Add(propName, $"'{stringValue}'");
                    }
                    else
                    {
                        result.Add(propName, $"''");
                    }
                }
                else if (prop.PropertyType == typeof(char) || prop.PropertyType == typeof(DateTime))
                {
                    result.Add(propName, $"'{valueOfProp}'");
                }
                else if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && valueOfProp == null)
                {
                    result.Add(propName, "NULL");
                }
                else if (prop.PropertyType == typeof(DateTime?) && valueOfProp != null)
                {
                    result.Add(propName, $"'{valueOfProp}'");
                }
                else if (prop.PropertyType == typeof(SqlGeography))
                {
                    if (valueOfProp == null)
                    {
                        result.Add(propName, "NULL");
                    }
                    else
                    {
                        var sqlGeography = (SqlGeography)valueOfProp;
                        result.Add(propName, $"geography::Point({sqlGeography.Lat}, {sqlGeography.Long}, 4326)");
                    }

                }
                else if (prop.PropertyType == typeof(bool) || (prop.PropertyType == typeof(bool?) && valueOfProp != null))
                {
                    if ((bool)valueOfProp)
                    {
                        result.Add(propName, "1");
                    }
                    else
                    {
                        result.Add(propName, "0");
                    }
                }
                else if (prop.PropertyType.IsEnum)
                {
                    //Get the underlying type of the enum. Int, bit. etc...
                    var underlyingType = Enum.GetUnderlyingType(prop.PropertyType);
                    //Use reflection to get value of the type we want.
                    var value = Convert.ChangeType(valueOfProp, underlyingType);
                    result.Add(propName, value.ToString());
                }
                else
                {
                    result.Add(propName, valueOfProp.ToString());
                }

            }

            return result;
        }
    }
}
