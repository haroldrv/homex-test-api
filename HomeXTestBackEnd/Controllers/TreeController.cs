using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HomeXTest.Domain.Models;
using HomeXTest.RepositoryInterfaces;

namespace HomeXTest.API.Controllers
{
    public class TreeController : ApiController
    {
        private readonly IRepository<Activity> _activitiesRepo;

        public TreeController(IRepository<Activity> activitiesRepo)
        {
            _activitiesRepo = activitiesRepo;
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
                node.Children = await BuildTreeAsync(node);
            }

            return Ok(nodes);
        }

        private async Task<List<ActivityNode>> BuildTreeAsync(ActivityNode node)
        {

            var children = await _activitiesRepo.GetAll()
                .Where(activity => activity.parent_activity_id == node.Id)
                .ToListAsync();

            if (!children.Any())
                return null;

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
                child.Children = await BuildTreeAsync(child);
            }

            return node.Children;
        }
    }
}
