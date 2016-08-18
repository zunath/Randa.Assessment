using Randa.Assessment.Domain.Contracts.DataImporter;

namespace Randa.Assessment.Application.Services.Contracts
{
    public interface IDataProcessorService
    {
        void ProcessData<T>(string dataSourceId)
            where T : IDataRecord;
    }
}
