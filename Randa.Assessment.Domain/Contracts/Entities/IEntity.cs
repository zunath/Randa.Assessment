using System.Collections.Generic;
using FluentValidation.Results;

namespace Randa.Assessment.Domain.Contracts.Entities
{
    public interface IEntity
    {
        bool IsValid(out IList<ValidationFailure> errors);
    }
}
