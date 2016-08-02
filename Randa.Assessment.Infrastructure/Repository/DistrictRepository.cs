using Randa.Assessment.Domain.Contracts;
using Randa.Assessment.Domain.Entities;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Domain.Services.Query.Results;

namespace Randa.Assessment.Infrastructure.Repository
{
    public class DistrictRepository: IDistrictRepository
    {
        private IValidatorFactory _factory;
        public DistrictRepository(IValidatorFactory factory)
        {
            _factory = factory;
        }

        public DistrictListQueryResult GetActiveDistricts()
        {
            DistrictListQueryResult result = new DistrictListQueryResult();
            result.Add(new District(0, _factory) { Name = "district 1", DistrictId = 1 });
            result.Add(new District(0, _factory) { Name = "district 2", DistrictId = 2 });
            result.Add(new District(0, _factory) { Name = "district 3", DistrictId = 3 });
            result.Add(new District(0, _factory) { Name = "district 4", DistrictId = 4 });
            result.Add(new District(0, _factory) { Name = "district 5", DistrictId = 5});

            return result;
        }
    }
}
