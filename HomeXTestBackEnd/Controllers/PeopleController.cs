using System.Web.Http;

namespace HomeXTest.API.Controllers
{
    public class PeopleController: ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
            //TODO call HomeX API and return data
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            //TODO call HomeX API and return data
            return Ok();
        }
    }
}