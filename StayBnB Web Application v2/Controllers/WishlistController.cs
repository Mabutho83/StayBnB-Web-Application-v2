using Microsoft.AspNetCore.Mvc;

namespace StayBnB_Web_Application_v2.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
