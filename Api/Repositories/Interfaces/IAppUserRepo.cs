using KeuzeWijzerApi.DAL.DataEntities;

namespace KeuzeWijzerApi.Repositories.Interfaces
{
    public interface IAppUserRepo : IRepository<AppUser>
    {
        Task<AppUser?> GetByAzureAdId(string azureAdId);
    }
}
