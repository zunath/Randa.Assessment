using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randa.Assessment.CQRS.Contracts;
using Randa.Assessment.Domain.Entities;

namespace Randa.Assessment.CQRS.Queries.Handlers
{
    public class GetActiveDistrictsHandler: IQueryHandler<GetActiveDistrictsQuery, List<District>>
    {
        public List<District> Execute(GetActiveDistrictsQuery query)
        {
            List<District> districts = new List<District>();
            districts.Add(new District(0) { Name = "District1", DistrictId = 1 });
            districts.Add(new District(0) { Name = "District2", DistrictId = 2 });
            districts.Add(new District(0) { Name = "District3", DistrictId = 3 });
            districts.Add(new District(0) { Name = "District4", DistrictId = 4 });
            districts.Add(new District(0) { Name = "District5", DistrictId = 5 });

            return districts;
        }
    }
}
