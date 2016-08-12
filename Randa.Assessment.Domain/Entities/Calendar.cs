using Randa.Assessment.Domain.Contracts;
using Randa.Assessment.Domain.Contracts.Entities;

namespace Randa.Assessment.Domain.Entities
{
    public class Calendar: BaseEntity
    {
        public Calendar(int userId, IValidatorFactory validatorFactory) 
            : base(userId, validatorFactory)
        {
        }
    }
}
