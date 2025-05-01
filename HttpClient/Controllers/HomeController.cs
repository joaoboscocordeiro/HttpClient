using Microsoft.AspNetCore.Mvc;

namespace HttpClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
