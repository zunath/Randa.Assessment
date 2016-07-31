using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using System.Web.OData;
using Randa.Assessment.CQRS.Contracts;
using Randa.Assessment.CQRS.Queries;
using Randa.Assessment.Domain.Entities;

namespace Randa.Assessment.Api.Controllers
{
    [EnableCors(origins: "http://localhost:63628", headers: "*", methods: "*")]
    public class DistrictController : ODataController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public DistrictController() { }

        public DistrictController(IQueryDispatcher queryDispatcher, 
            ICommandDispatcher commandDispatcher )
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public IQueryable<District> Get()
        {
            GetActiveDistrictsQuery query = new GetActiveDistrictsQuery();

            return _queryDispatcher.Execute<GetActiveDistrictsQuery, List<District>>(query).AsQueryable();
        }



    }
}
