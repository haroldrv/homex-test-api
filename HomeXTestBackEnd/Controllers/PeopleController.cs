using System.Collections.Generic;
using System.Web.Http;

namespace HomeXTest.API.Controllers
{
    public class PeopleController: ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }
    }
}