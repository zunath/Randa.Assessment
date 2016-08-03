using Randa.Assessment.Domain.Services.Contracts.CQRS;
using Randa.Assessment.Domain.Services.Contracts.Repository;
using Randa.Assessment.Domain.Services.Query.Districts.Result;

namespace Randa.Assessment.Domain.Services.Query.Districts.Handler
{
    public class GetActiveDistrictsHandler: IQueryHandler<GetActiveDistrictsQuery, DistrictListQueryResult>
    {
        private readonly IDistrictRepository _districtRepository;
        public GetActiveDistrictsHandler(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public DistrictListQueryResult Execute(GetActiveDistrictsQuery query)
        {
            return _districtRepository.GetActiveDistricts();
        }
    }
}
