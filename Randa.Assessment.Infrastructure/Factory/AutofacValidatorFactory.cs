using System;
using Autofac;
using FluentValidation;

namespace Randa.Assessment.Infrastructure.Factory
{
    public class AutofacValidatorFactory: ValidatorFactoryBase, Domain.Contracts.Entities.IValidatorFactory
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
