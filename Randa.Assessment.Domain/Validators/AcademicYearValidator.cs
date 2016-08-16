using FluentValidation;
using Randa.Assessment.Domain.Entities;

namespace Randa.Assessment.Domain.Validators
{
    public class AcademicYearValidator: AbstractValidator<AcademicYear>
    {
        public AcademicYearValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.DateStart)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.DateEnd)
                .NotEmpty()
                .NotNull()
                .GreaterThan(y => y.DateStart)
                .WithMessage("End date must be after start date.");
        }
    }
}
