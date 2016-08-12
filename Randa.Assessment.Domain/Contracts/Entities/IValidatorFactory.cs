using System;
using FluentValidation;

namespace Randa.Assessment.Domain.Contracts.Entities
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidator<T>();
        IValidator GetValidator(Type type);
    }
}
