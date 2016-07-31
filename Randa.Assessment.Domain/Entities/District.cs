using System;
using System.Collections.Generic;
using FluentValidation.Results;
using Randa.Assessment.Domain.Validators;

namespace Randa.Assessment.Domain.Entities
{
    public class District: BaseEntity
    {
        public int DistrictId { get; set; }
        public int StateId { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }

        public District(int userId) 
            : base(userId)
        {
        }

        public override bool IsValid(out IList<ValidationFailure> errors)
        {
            var result = new DistrictValidator().Validate(this);
            errors = result.Errors;
            return result.IsValid;
        }
    }
}
