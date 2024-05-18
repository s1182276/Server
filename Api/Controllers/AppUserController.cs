﻿using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Services.Interfaces;
using KeuzeWijzerCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.Net.Http.Headers;

namespace KeuzeWijzerApi.Controllers
{
    [Authorize]
    [RequiredScope("All", "AppUser")]
    [ApiController]
    [Route("[controller]")]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<AppUserDto> GetAuthenticatedUser()
        {
            AppUser appUser = await _appUserService.GetAuthenticatedAppUserAsync();
            return _mapper.Map<AppUser, AppUserDto>(appUser);
        }
    }
}