using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using KeuzeWijzerCore.AuthorizationPolicies;

namespace KeuzeWijzerMvc.Controllers
{
    [AuthorizeIsInAdministratorGroup]
    public class HomeController : Controller
    {
        private readonly ITokenAcquisition _tokenAcquisition;

        public HomeController(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task<IActionResult> Index()
        {
            // For some odd reason we need to initialize ITokenAcquisition this way.
            // Otherwise getting a token throws exceptions
            try
            {
                await _tokenAcquisition.GetAccessTokenForUserAsync([]);
            } 
            catch (MicrosoftIdentityWebChallengeUserException)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);
            }
            catch (MsalClientException)
            {
                // Do nothing.. this gets thrown when token cache is full. in which case we know we can get tokens.
            }

            return View();
        }
    }
}
