using System;

namespace Randa.Assessment.CQRS.Contracts
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
