using System;

namespace Randa.Assessment.Application.Services.Contracts
{
    public interface IDataImporterService
    {
        void ImportDataFile(string sourceId, string filePath, Type type);
    }
}
