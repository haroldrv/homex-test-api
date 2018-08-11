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
    public class TreeController : ApiController
    {
        private readonly IRepository<Activity> _activitiesRepo;
        private readonly IRepository<ActivitiesPeople> _activityPeopleRepo;
        private readonly HttpClient _client = new HttpClient();

        public TreeController(
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

        public async Task<IHttpActionResult> Get()
        {
            var nodes = new List<ActivityNode>();
            var rootNodes = await _activitiesRepo.GetAll()
                .Where(activity => !activity.parent_activity_id.HasValue)
                .ToListAsync();

            if (!rootNodes.Any())
                return BadRequest("No root found");

            foreach (var rootNode in rootNodes)
            {
                var root = new ActivityNode
                {
                    Id = rootNode.id,
                    Name = rootNode.name,
                    ParentActivityId = null,
                    Children = new List<ActivityNode>(),
                    People = new List<Person>()
                };

                nodes.Add(root);
            }

            foreach (var node in nodes)
            {
                node.Children = await GetChildNodesAsync(node);
            }

            return Ok(nodes);
        }

        private async Task<List<ActivityNode>> GetChildNodesAsync(ActivityNode node)
        {
            var children = await _activitiesRepo.GetAll()
                .Where(activity => activity.parent_activity_id == node.Id)
                .ToListAsync();

            if (!children.Any())
                return new List<ActivityNode>();

            foreach (var child in children)
            {
                var root = new ActivityNode
                {
                    Id = child.id,
                    Name = child.name,
                    ParentActivityId = child.parent_activity_id,
                    Children = new List<ActivityNode>(),
                    People = new List<Person>()
                };

                node.Children.Add(root);
            }

            foreach (var child in node.Children)
            {
                child.Children = await GetChildNodesAsync(child);
                child.People = await GetPeopleAsync(child);
            }

            return node.Children;
        }

        private async Task<List<Person>> GetPeopleAsync(ActivityNode node)
        {
            var people = new List<Person>();
            var activityPeopleIds = await _activityPeopleRepo.GetAll()
                .Where(ap => ap.activity_id == node.Id)
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

            return people;
        }
    }
}