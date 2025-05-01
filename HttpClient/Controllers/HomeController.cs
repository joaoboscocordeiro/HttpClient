using HttpClientWeb.Dtos.Login;
using HttpClientWeb.Dtos.Usuario;
using HttpClientWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace HttpClientWeb.Controllers
{
    public class HomeController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:7239/api");

        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrl;
        }

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

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
        {
            if (ModelState.IsValid)
            {
                ResponseModel<UsuarioModel> usuario = new ResponseModel<UsuarioModel>();

                var httpContent = new StringContent(JsonConvert.SerializeObject(usuarioLoginDto), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Login/Login", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<ResponseModel<UsuarioModel>>(data);
                }

                if (usuario.Status == false)
                {
                    return View(usuarioLoginDto);
                }

                return RedirectToAction("ListarUsuarios");
            }
            else
            {
                return View(usuarioLoginDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            if (ModelState.IsValid)
            {
                ResponseModel<UsuarioModel> usuario = new ResponseModel<UsuarioModel>();

                var httpContent = new StringContent(JsonConvert.SerializeObject(usuarioCriacaoDto), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Login/register", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<ResponseModel<UsuarioModel>>(data);
                }

                if (usuario.Status == false)
                {
                    return View(usuarioCriacaoDto);
                }

                return RedirectToAction("ListarUsuarios");
            }
            else
            {
                return View(usuarioCriacaoDto);
            }
        }
    }
}
