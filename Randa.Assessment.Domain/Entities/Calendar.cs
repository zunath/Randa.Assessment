using Randa.Assessment.Domain.Contracts;

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
