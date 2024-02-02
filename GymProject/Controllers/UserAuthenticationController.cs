using GymProject.Areas.Identity.Data;
using GymProject.Controllers.Core;
using GymProject.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers
{
    public class UserAuthenticationController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        public UserAuthenticationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            else return Redirect("/Home/Index");
        }
    }
}
