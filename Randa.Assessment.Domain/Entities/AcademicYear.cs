using System.Collections.Generic;
using FluentValidation.Results;
using Randa.Assessment.Domain.Contracts;
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
        
        public AcademicYear(int userId, IValidatorFactory validatorFactory) 
            : base(userId, validatorFactory)
        {
        }
    }

    

}
