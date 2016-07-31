using System;

namespace Randa.Assessment.Domain.Services.Command
{
    public class CreateDistrictCommand: Command
    {
        public CreateDistrictCommand(Guid id, int version) 
            : base(id, version)
        {
        }
    }
}
