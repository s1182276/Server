using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.DAL.Repositories.Interfaces;
using KeuzeWijzerApi.Services.Interfaces;
using KeuzeWijzerCore.Enums;
using Microsoft.Graph;

namespace KeuzeWijzerApi.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IConfigurationSection _groupsConfigurationSection;
        private readonly IAppUserRepo _appUserRepo;
        private readonly GraphServiceClient _graphServiceClient;
        private readonly Dictionary<string, AppUserRole> _groupsAppUserRoleTranslation;

        public AppUserService(IConfiguration configuration, IAppUserRepo appUserRepo, GraphServiceClient graphServiceClient)
        {
            _groupsConfigurationSection = configuration.GetRequiredSection("Groups");
            _appUserRepo = appUserRepo;
            _graphServiceClient = graphServiceClient;

            _groupsAppUserRoleTranslation = new Dictionary<string, AppUserRole>()
            {
                { _groupsConfigurationSection["StudentGroupId"]!, AppUserRole.Student },
                { _groupsConfigurationSection["StudentSupervisorGroupId"]!, AppUserRole.StudentSupervisor },
                { _groupsConfigurationSection["AdministratorGroupId"]!, AppUserRole.Administrator }
            };
        }

        public bool Exists(int userId)
        {
            return _appUserRepo.DoesExist(userId);
        }

        public async Task<AppUser> GetAuthenticatedAppUserAsync()
        {
            User? currentUser = await _graphServiceClient.Me.Request().GetAsync();
            if(currentUser.Id == null)
            {
                throw new Exception("Current user does not have an AzureAD ID");
            }

            AppUser? appUser = await _appUserRepo.GetByAzureAdId(currentUser.Id);
            if(appUser == null)
            {
                appUser = new AppUser()
                {
                    AzureAdId = currentUser.Id,
                    IsFirstSignIn = true, // When we create a new app user this means its their first sign in.
                };

                await _appUserRepo.Add(appUser);
            }

            // Extend information using data returned by graph
            appUser.DisplayName = currentUser.DisplayName;
            appUser.AppUserRole = await GetAuthenticatedAppUserRole();

            return appUser;
        }


        public async Task UpdateAsync(AppUser appUser)
        {
            await _appUserRepo.Update(appUser);
        }

        private async Task<AppUserRole> GetAuthenticatedAppUserRole()
        {
            var userGroups = await _graphServiceClient.Me.CheckMemberGroups(GetAllConfiguredGroups()).Request().PostAsync();
            var userRole = userGroups.Distinct()
                .Select(groupId => _groupsAppUserRoleTranslation[groupId])
                .Aggregate((prev, next) => prev | next);

            return userRole;
        }

        private IEnumerable<string> GetAllConfiguredGroups() => _groupsConfigurationSection.AsEnumerable().Where(x => x.Value != null).Select(x => x.Value);
    }
}
