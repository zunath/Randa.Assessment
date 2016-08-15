using System;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Command.DataProcessor
{
    public class ProcessDataHandler : ICommandHandler<ProcessDataCommand>
    {
        public void Execute(ProcessDataCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
