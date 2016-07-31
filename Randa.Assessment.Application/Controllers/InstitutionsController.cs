using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Randa.Assessment.Domain.Services.Contracts;
using Randa.Assessment.Domain.Services.Query;
using Randa.Assessment.Domain.Services.Query.Results;

namespace Randa.Assessment.Application.Controllers
{
    public class InstitutionsController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public InstitutionsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        // GET: Institutions
        public ActionResult Index()
        {
            GetActiveDistrictsQuery query = new GetActiveDistrictsQuery();

            DistrictListQueryResult result =
                _queryDispatcher.Execute<GetActiveDistrictsQuery, DistrictListQueryResult>(query);

            return View(result);
        }
    }
}