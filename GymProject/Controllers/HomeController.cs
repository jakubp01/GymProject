using GymProject.Controllers.Core;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
