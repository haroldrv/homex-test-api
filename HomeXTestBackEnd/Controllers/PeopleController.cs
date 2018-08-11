using HomeXTest.Domain.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeXTest.API.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly HttpClient _client = new HttpClient();

        public PeopleController()
        {
            _client.BaseAddress = new Uri("http://interview.homex.io/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid person id");

            Person person;
            var uri = $"http://interview.homex.io/api/people/{id}";
            var response = await _client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
                return NotFound();

            try
            {
                person = await response.Content.ReadAsAsync<Person>();
            }
            catch (Exception)
            {
                // Do not return stack traces (write to a log/email instead)
                return InternalServerError();
            }
            
            return Ok(person);
        }
    }
}