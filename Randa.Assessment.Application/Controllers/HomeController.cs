using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Results;
using Randa.Assessment.Domain.Contracts.Entities;
using Randa.Assessment.Domain.Entities;

namespace Randa.Assessment.Application.Controllers
{
    public class HomeController : Controller
    {
        private IValidatorFactory _factory;

        public HomeController(IValidatorFactory factory)
        {
            _factory = factory;
        }

        // GET: Home
        public ActionResult Index()
        {
            District district = new District(0, _factory);
            
            IList<ValidationFailure> fail = new List<ValidationFailure>();
            bool valid = district.IsValid(out fail);

            return View();
        }
    }
}