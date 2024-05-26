using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DAL.Repositories
{
    public class ModuleRepo : IModuleRepo
    {
        private readonly KeuzeWijzerContext _context;

        public ModuleRepo(KeuzeWijzerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(SchoolModule entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.SchoolModules.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SchoolModule entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.SchoolModules.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SchoolModule>> GetAll()
        {
            return await _context.SchoolModules
                .Include(sm => sm.SchoolYear)
                .Include(sm => sm.EntryRequirementModules)
                .ToListAsync();
        }

        public async Task<SchoolModule> GetById(int id)
        {
            return await _context.SchoolModules
                .Include(sm => sm.SchoolYear)
                .Include(sm => sm.EntryRequirementModules)
                .FirstOrDefaultAsync(sm => sm.Id == id);
        }

        public async Task Update(SchoolModule entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.SchoolModules.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool DoesExist(int id)
        {
            return _context.SchoolModules.Any(e => e.Id == id);
        }
    }
}
