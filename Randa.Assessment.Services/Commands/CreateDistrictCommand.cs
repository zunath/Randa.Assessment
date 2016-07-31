using System;

namespace Randa.Assessment.CQRS.Commands
{
    public class CreateDistrictCommand: Command
    {
        public CreateDistrictCommand(Guid id, int version) 
            : base(id, version)
        {
        }
    }
}
