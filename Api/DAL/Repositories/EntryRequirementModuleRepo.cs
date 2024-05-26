using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;

namespace KeuzeWijzerApi.Repositories
{
    public class EntryRequirementModuleRepo : IEntryRequirementModuleRepo
    {
        private readonly KeuzeWijzerContext _context;

        public EntryRequirementModuleRepo(KeuzeWijzerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(EntryRequirementModule entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.EntryRequirementModules.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Delete(EntryRequirementModule entity)
        {
            throw new NotImplementedException();
        }

        public bool DoesExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntryRequirementModule>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EntryRequirementModule?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(EntryRequirementModule entity)
        {
            throw new NotImplementedException();
        }
    }
}