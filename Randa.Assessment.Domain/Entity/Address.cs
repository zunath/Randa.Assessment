using Randa.Assessment.Domain.Contracts.Entities;

namespace Randa.Assessment.Domain.Entity
{
    public class Address: BaseEntity
    {
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string PostalCode { get; set; }


        public Address(int userId, IValidatorFactory validatorFactory) 
            : base(userId, validatorFactory)
        {
        }
    }
}
