using Autofac;
using Randa.Assessment.Domain.Contracts.DataProcessor;

namespace Randa.Assessment.Infrastructure.Factory
{
    public class DataRecordProcessorFactory: IDataRecordProcessorFactory
    {
        private readonly IComponentContext _context;

        public DataRecordProcessorFactory(IComponentContext context)
        {
            _context = context;
        }

        public IDataRecordProcessor CreateDataRecordProcessor(string dataSourceId)
        {
            dataSourceId = dataSourceId.ToUpper();
            var processor = _context.ResolveKeyed<IDataRecordProcessor>(dataSourceId);
            return processor;
        }
    }
}
