using System;

namespace Randa.Assessment.Domain.Services.Contracts.CQRS
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
