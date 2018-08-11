using System.Linq;
using System.Threading.Tasks;

namespace HomeXTest.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> Get(int id);
    }
}