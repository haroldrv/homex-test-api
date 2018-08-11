using HomeXTest.RepositoryInterfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HomeXTest.Repository
{
    public class HomeXTestRepository<TEntity> :  IRepository<TEntity> where TEntity : class
    {
        internal HomeXTestDbContext Context;
        internal DbSet<TEntity> DbSet;

        public HomeXTestRepository()
        {
            Context = new HomeXTestDbContext();
            DbSet = Context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }
    }
}