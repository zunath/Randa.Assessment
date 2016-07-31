using FluentValidation;
using Randa.Assessment.Domain.Entities;

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
