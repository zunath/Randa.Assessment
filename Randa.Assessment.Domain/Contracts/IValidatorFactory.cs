using System;
using FluentValidation;

namespace Randa.Assessment.Domain.Contracts
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidator<T>();
        IValidator GetValidator(Type type);
    }
}
