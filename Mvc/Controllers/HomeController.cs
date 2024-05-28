using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;

namespace KeuzeWijzerMvc.Controllers
{
    [Authorize]
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
            catch (Exception) // Catch Exception because catching the specific MsalUiRequiredException doesnt get caught for some reason
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);
            }

            return View();
        }
    }
}
