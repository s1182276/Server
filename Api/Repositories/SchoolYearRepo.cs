using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.Repositories
{
    public class SchoolYearRepo : ISchoolYearRepo
    {
        private readonly KeuzeWijzerContext _context;

        public SchoolYearRepo(KeuzeWijzerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(SchoolYear entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.SchoolYears.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SchoolYear entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.SchoolYears.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool DoesExist(int id)
        {
            return _context.SchoolYears.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<SchoolYear>> GetAll()
        {
            return await _context.SchoolYears.Include(sy => sy.SchoolModules).ToListAsync();
        }

        public async Task<SchoolYear> GetById(int id)
        {
            return await _context.SchoolYears.FindAsync(id);
        }

        public async Task Update(SchoolYear entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.SchoolYears.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
