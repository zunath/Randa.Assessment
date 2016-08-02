using Randa.Assessment.Domain.Contracts;

namespace Randa.Assessment.Domain.Entities
{
    public class District: BaseEntity
    {
        public int DistrictId { get; set; }
        public int StateId { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }

        public District(int userId, IValidatorFactory validatorFactory) 
            : base(userId, validatorFactory)
        {
        }
    }
}
