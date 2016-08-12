using System.Web.Mvc;
using Randa.Assessment.Domain.Services.Contracts.CQRS;

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
            return View();
        }
    }
}