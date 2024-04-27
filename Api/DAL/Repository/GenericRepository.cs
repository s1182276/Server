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
    
    public async Task<T> GetById(object id)
    {
        return await table.FindAsync(id);
    }
    
    public async Task Insert(T obj)
    {
        await table.AddAsync(obj);
    }
        
    public void Update(T obj)
    {
        table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
    }
    public async Task Delete(object id)
    {
        T existing = await table.FindAsync(id);
        table.Remove(existing);
    }
    
    public async Task<List<T>> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] children)
    {         
        IQueryable<T> query = table;
        foreach (string entity in children)
        {
            query = query.Include(entity);

        }
        return await query.Where(filter).ToListAsync();            
    }

    public async Task Save()
    {
        _context.SaveChangesAsync();
    }
}
