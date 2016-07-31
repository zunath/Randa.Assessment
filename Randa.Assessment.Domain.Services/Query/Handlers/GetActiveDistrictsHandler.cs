using Randa.Assessment.Domain.Entities;
using Randa.Assessment.Domain.Services.Contracts;
using Randa.Assessment.Domain.Services.Query.Results;
using Randa.Assessment.Domain.Services.Repository;

namespace Randa.Assessment.Domain.Services.Query.Handlers
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
