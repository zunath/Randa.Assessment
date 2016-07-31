using System.Collections.Generic;
using Randa.Assessment.CQRS.Contracts;
using Randa.Assessment.Domain.Entities;

namespace Randa.Assessment.CQRS.Queries.Results
{
    public class DistrictListQueryResult: List<District>, IQueryResult
    {
    }
}
