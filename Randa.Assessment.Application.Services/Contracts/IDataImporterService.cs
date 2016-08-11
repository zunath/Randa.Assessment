using System;

namespace Randa.Assessment.Application.Services.Contracts
{
    public interface IDataImporterService
    {
        void ImportDataFile(string dataSourceId, string filePath, Type type);
    }
}
