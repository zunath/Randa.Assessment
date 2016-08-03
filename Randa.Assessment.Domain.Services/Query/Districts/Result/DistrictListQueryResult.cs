using System.Collections.Generic;
using Randa.Assessment.Domain.Entities;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

namespace Randa.Assessment.Domain.Services.Query.Districts.Result
{
    public class DistrictListQueryResult: List<District>, IQueryResult
    {
    }
}
