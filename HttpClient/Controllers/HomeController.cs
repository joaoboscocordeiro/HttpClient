using HttpClient.Dtos.Login;
using Microsoft.AspNetCore.Mvc;

namespace HttpClient.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioLoginDto usuarioLoginDto)
        {
            return View(usuarioLoginDto);
        }
    }
}
