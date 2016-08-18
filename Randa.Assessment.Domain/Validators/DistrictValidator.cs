using FluentValidation;
using Randa.Assessment.Domain.Entity;

namespace Randa.Assessment.Domain.Validators
{
    public class DistrictValidator: AbstractValidator<District>
    {
        public DistrictValidator()
        {
            RuleFor(x => x.Name)
                .Length(0, 100);
        }
    }
}
