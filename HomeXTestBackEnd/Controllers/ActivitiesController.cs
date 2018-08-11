using HomeXTest.Domain.Models;
using HomeXTest.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeXTest.API.Controllers
{
    public class ActivitiesController: ApiController
    {
        private readonly IRepository<Activity> _activitiesRepo;
        private readonly IRepository<ActivitiesPeople> _activityPeopleRepo;
        private readonly HttpClient _client = new HttpClient();

        public ActivitiesController(
            IRepository<Activity> activitiesRepo, 
            IRepository<ActivitiesPeople> activityPeopleRepo)
        {
            _activitiesRepo = activitiesRepo;
            _activityPeopleRepo = activityPeopleRepo;

            _client.BaseAddress = new Uri("http://interview.homex.io/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        [Route("api/activities")]
        public async Task<IHttpActionResult> GetAll()
        {
            var activities = await _activitiesRepo
                .GetAll()
                .ToListAsync();

            return Ok(activities);
        }

        [HttpGet]
        [Route("api/activities/{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var activity = await _activitiesRepo.Get(id);

            if (activity == null)
                return NotFound();

            return Ok(activity);
        }

        [HttpGet]
        [Route("api/activities/{id:int}/children")]
        public async Task<IHttpActionResult> GetChildren(int id)
        {
            var activities = await _activitiesRepo
                .GetAll()
                .Where(activity => activity.parent_activity_id == id)
                .ToListAsync();

            return Ok(activities);
        }

        [HttpGet]
        [Route("api/activities/{id:int}/people")]
        public async Task<IHttpActionResult> GetPeople(int id)
        {
            var people = new List<Person>();
            var activityPeopleIds = await _activityPeopleRepo.GetAll()
                .Where(ap => ap.activity_id == id)
                .Select(ap => ap.person_id)
                .ToListAsync();

            foreach (var personId in activityPeopleIds)
            {
                var uri = $"http://interview.homex.io/api/people/{personId}";
                var response = await _client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                    continue;

                var person = await response.Content.ReadAsAsync<Person>();
                people.Add(person);
            }

            return Ok(people);
        }
    }
}