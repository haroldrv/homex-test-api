using HomeXTest.Repository;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeXTest.API.Controllers
{
    public class ActivitiesController: ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var context = new HomeXTestDbContext();
            var activities = await context.activities.ToListAsync();

            return Ok(activities);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var context = new HomeXTestDbContext();
            var activity = await context.activities.FirstOrDefaultAsync(a => a.id == id);

            if (activity == null)
                return NotFound();

            return Ok(activity);
        }
    }
}