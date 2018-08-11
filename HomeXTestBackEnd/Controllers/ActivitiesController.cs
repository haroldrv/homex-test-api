using System.Collections.Generic;
using HomeXTest.Domain.Models;
using HomeXTest.RepositoryInterfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeXTest.API.Controllers
{
    public class ActivitiesController: ApiController
    {
        private readonly IRepository<Activity> _activitiesRepo;

        public ActivitiesController(IRepository<Activity> activitiesRepo)
        {
            _activitiesRepo = activitiesRepo;
        }

        public async Task<IHttpActionResult> GetAll()
        {
            var activities = await _activitiesRepo
                .GetAll()
                .ToListAsync();

            return Ok(activities);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var activity = await _activitiesRepo.Get(id);

            if (activity == null)
                return NotFound();

            return Ok(activity);
        }
    }
}