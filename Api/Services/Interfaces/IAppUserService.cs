using KeuzeWijzerApi.DAL.DataEntities;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface IAppUserService
    {
        public Task<AppUser> GetAuthenticatedAppUserAsync();
    }
}
