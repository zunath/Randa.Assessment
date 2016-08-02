using System;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Command
{
    public class Command: ICommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }

        public Command(Guid id, int version)
        {
            Id = id;
            Version = version;
        }

    }
}
