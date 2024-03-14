using Microsoft.AspNetCore.Mvc;

namespace SamiPotterOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}