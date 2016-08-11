using Randa.Assessment.Domain.Services.Query.Districts;

namespace Randa.Assessment.Domain.Services.Contracts.Repository
{
    public interface IDistrictRepository
    {
        DistrictListQueryResult GetActiveDistricts();
    }
}
