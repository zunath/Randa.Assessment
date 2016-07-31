using System.Collections.Generic;
using FluentValidation.Results;

namespace Randa.Assessment.Domain.Contracts
{
    public interface IEntity
    {
        bool IsValid(out IList<ValidationFailure> errors);
    }
}
