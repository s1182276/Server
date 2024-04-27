using System.Linq.Expressions;

namespace KeuzeWijzerApi.DAL.Repository;

public interface IGenericRepository<T> where T : class
{
    List<T> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children);

    IQueryable<T> GetAll();
    T GetById(object id);
    void Insert(T obj);
    void Update(T obj);
    void Delete(object id);
    void Save();
}