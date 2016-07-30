using System.Collections.Generic;
using System.Linq;
using System.Web.OData;
using Randa.Assessment.Api.Models;

namespace Randa.Assessment.Api.Controllers
{
    public class DistrictsController : ODataController
    {

        public IQueryable<District> Get()
        {
            List<District> districts = new List<District>();
            districts.Add(new District { Id = 1, Name = "District 1" });
            districts.Add(new District { Id = 2, Name = "District 2" });
            districts.Add(new District { Id = 3, Name = "District 3" });
            districts.Add(new District { Id = 4, Name = "District 4" });
            districts.Add(new District { Id = 5, Name = "District 5" });

            return districts.AsQueryable();
        }

    }
}
