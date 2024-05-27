using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DAL.Repositories
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly KeuzeWijzerContext _context;

        public AppUserRepo(KeuzeWijzerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(AppUser entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.AppUsers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(AppUser entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.AppUsers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool DoesExist(int id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser?> GetById(int id)
        {
            return await _context.AppUsers.FindAsync(id);
        }

        public async Task<AppUser?> GetByAzureAdId(string azureAdId)
        {
            AppUser? appUser = await _context.AppUsers.FirstOrDefaultAsync(x => !string.IsNullOrEmpty(x.AzureAdId) && x.AzureAdId.Equals(azureAdId));
            return appUser;
        }

        public async Task Update(AppUser entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.AppUsers.Update(entity);
            _context.Entry(entity).Property(x => x.AzureAdId).IsModified = false; // Prevent updating of AzureAdId
            await _context.SaveChangesAsync();
        }
    }
}
