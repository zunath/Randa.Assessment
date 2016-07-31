using System;

namespace Randa.Assessment.Domain.Services.Contracts
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
