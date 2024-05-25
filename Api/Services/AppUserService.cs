﻿using Azure.Identity;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;
using KeuzeWijzerApi.Services.Interfaces;
using Microsoft.Graph;

namespace KeuzeWijzerApi.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepo _appUserRepo;
        private readonly GraphServiceClient _graphServiceClient;

        public AppUserService(IAppUserRepo appUserRepo, GraphServiceClient graphServiceClient)
        {
            _appUserRepo = appUserRepo;
            _graphServiceClient = graphServiceClient;
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
                };

                await _appUserRepo.Add(appUser);
            }

            // Extend information using data returned by graph
            appUser.DisplayName = currentUser.DisplayName;

            return appUser;
        }
    }
}
