using KeuzeWijzerApi.DAL.DataEntities;

namespace KeuzeWijzerApi.DAL.Repositories.Interfaces
{
    public interface IAppUserRepo : IRepository<AppUser>
    {
        Task<AppUser?> GetByAzureAdId(string azureAdId);
    }
}
