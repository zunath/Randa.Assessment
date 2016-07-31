using System.Linq;
using Randa.Assessment.Domain.Entities;
using Randa.Assessment.Domain.Services.Query.Results;

namespace Randa.Assessment.Domain.Services.Repository
{
    public interface IDistrictRepository
    {
        DistrictListQueryResult GetActiveDistricts();
    }
}
