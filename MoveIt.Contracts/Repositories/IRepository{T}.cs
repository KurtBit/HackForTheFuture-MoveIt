using System.Linq;

namespace MoveIt.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Save();

        void Insert(T entity);

        void Delete(T entity);

        void Update(T entity);

        T GetById(object id);

        IQueryable<T> GetAll();
    }
}
