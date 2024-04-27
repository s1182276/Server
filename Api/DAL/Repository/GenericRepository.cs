using System.Linq.Expressions;
using KeuzeWijzerApi.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DAL.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private KeuzeWijzerContext _context = null;
    public DbSet<T> table = null;
    
    public GenericRepository(KeuzeWijzerContext _context)
    {
        this._context = _context;
        table = _context.Set<T>();
    }
    
    public IQueryable<T> GetAll()
    {
        IQueryable<T> query = _context.Set<T>();
        return query;
    }
    
    public T GetById(object id)
    {
        return table.Find(id);
    }
    
    public void Insert(T obj)
    {
        table.Add(obj);
    }
        
    public void Update(T obj)
    {
        table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
    }
    public void Delete(object id)
    {
        T existing = table.Find(id);
        table.Remove(existing);
    }
    
    public  List<T> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children)
    {         
        IQueryable<T> query = table;
        foreach (string entity in children)
        {
            query = query.Include(entity);

        }
        return  query.Where(filter).ToList();            
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
