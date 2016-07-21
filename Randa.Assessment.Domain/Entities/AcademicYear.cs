using System.Collections.Generic;
using FluentValidation.Results;
using Randa.Assessment.Domain.Validators;

namespace Randa.Assessment.Domain.Entities
{
    using System;
    
    public class AcademicYear: BaseEntity
    {
        public int AcademicYearId { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public override bool IsValid(out IList<ValidationFailure> errors)
        {
            var result = new AcademicYearValidator().Validate(this);
            errors = result.Errors;
            return result.IsValid;
        }
        
        public AcademicYear(int userId) 
            : base(userId)
        {
        }
    }

    

}
