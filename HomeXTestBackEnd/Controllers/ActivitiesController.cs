using HomeXTest.Repository;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using HomeXTest.Domain.Models;
using HomeXTest.RepositoryInterfaces;

namespace HomeXTest.API.Controllers
{
    public class ActivitiesController: ApiController
    {
        private readonly IRepository<Activity> _activitiesRepo;

        public ActivitiesController(IRepository<Activity> activitiesRepo)
        {
            _activitiesRepo = activitiesRepo;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var activities = await _activitiesRepo
                .GetAll()
                .ToListAsync();

            return Ok(activities);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var activity = await _activitiesRepo.Get(id);

            if (activity == null)
                return NotFound();

            return Ok(activity);
        }
    }
}