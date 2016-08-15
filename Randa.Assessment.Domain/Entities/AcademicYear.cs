using Randa.Assessment.Domain.Contracts.Entities;

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
