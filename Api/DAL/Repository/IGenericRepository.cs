using System.Linq.Expressions;

namespace KeuzeWijzerApi.DAL.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children);

    IQueryable<T> GetAll();
    Task<T> GetById(object id);
    Task Insert(T obj);
    void Update(T obj);
    Task Delete(object id);
    Task Save();
}