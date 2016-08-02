using Randa.Assessment.Domain.Services.Query.Results;

namespace Randa.Assessment.Domain.Services.Contracts.Repository
{
    public interface IDistrictRepository
    {
        DistrictListQueryResult GetActiveDistricts();
    }
}
