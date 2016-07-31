using System;
using Randa.Assessment.CQRS.Contracts;

namespace Randa.Assessment.CQRS.Commands
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
