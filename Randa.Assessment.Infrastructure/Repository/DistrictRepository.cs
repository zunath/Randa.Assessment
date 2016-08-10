using Randa.Assessment.Domain.Contracts;
using Randa.Assessment.Domain.Entities;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Domain.Services.Query.Districts.Result;

namespace Randa.Assessment.Infrastructure.Repository
{
    public class DistrictRepository: IDistrictRepository
    {
        private readonly IValidatorFactory _factory;
        public DistrictRepository(IValidatorFactory factory)
        {
            _factory = factory;
        }

        public DistrictListQueryResult GetActiveDistricts()
        {
            DistrictListQueryResult result = new DistrictListQueryResult
            {
                new District(0, _factory) {Name = "district 1", DistrictId = 1},
                new District(0, _factory) {Name = "district 2", DistrictId = 2},
                new District(0, _factory) {Name = "district 3", DistrictId = 3},
                new District(0, _factory) {Name = "district 4", DistrictId = 4},
                new District(0, _factory) {Name = "district 5", DistrictId = 5}
            };

            return result;
        }
    }
}
