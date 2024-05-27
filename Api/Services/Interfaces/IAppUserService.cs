using KeuzeWijzerApi.DAL.DataEntities;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface IAppUserService
    {
        public Task<AppUser> GetAuthenticatedAppUserAsync();
        public Task UpdateAsync(AppUser appUser);
        public bool Exists(int userId);
    }
}
