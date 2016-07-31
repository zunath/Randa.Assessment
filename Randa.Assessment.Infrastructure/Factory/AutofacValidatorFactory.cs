using System;
using Autofac;
using FluentValidation;
using IValidatorFactory = Randa.Assessment.Domain.Contracts.IValidatorFactory;

namespace Randa.Assessment.Infrastructure.Factory
{
    public class AutofacValidatorFactory: ValidatorFactoryBase, IValidatorFactory
    {
        private readonly IComponentContext _context;
        public AutofacValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var validator = _context.ResolveOptionalKeyed<IValidator>(validatorType);
            return validator;
        }
    }
}
