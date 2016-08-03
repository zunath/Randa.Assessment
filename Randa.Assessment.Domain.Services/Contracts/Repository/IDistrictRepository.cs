using Randa.Assessment.Domain.Services.Query.Districts.Result;

namespace Randa.Assessment.Domain.Services.Contracts.Repository
{
    public interface IDistrictRepository
    {
        DistrictListQueryResult GetActiveDistricts();
    }
}
