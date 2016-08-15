using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Command.DataProcessor
{
    public class ProcessDataCommand: ICommand
    {
        public string DataSourceId { get; private set; }


        public static ProcessDataCommand Create(string dataSourceId)
        {
            return new ProcessDataCommand
            {
                DataSourceId = dataSourceId
            };
        }
    }
}
