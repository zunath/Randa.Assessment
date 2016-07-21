using System.Collections.Generic;
using System.Linq;
using System.Web.OData;
using Randa.Assessment.Api.Models;

namespace Randa.Assessment.Api.Controllers
{
    [EnableQuery]
    public class TestController : ODataController
    {
        public IQueryable<TestModel> Get()
        {
            List<TestModel> list = new List<TestModel>
            {
                new TestModel("New item 1"),
                new TestModel("New item 2"),
                new TestModel("New item 3"),
                new TestModel("New item 4")

            };

            return list.AsQueryable();
        } 
    }
}
