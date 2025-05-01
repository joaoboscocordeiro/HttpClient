using HttpClientWeb.Dtos.Login;
using HttpClientWeb.Dtos.Usuario;
using HttpClientWeb.Models;
using HttpClientWeb.Services.Sessao;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HttpClientWeb.Controllers
{
    public class HomeController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:7239/api");

        private readonly HttpClient _httpClient;
        private readonly ISessaoInterface _sessaoInterface;

        public HomeController(HttpClient httpClient, ISessaoInterface sessaoInterface)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrl;
            _sessaoInterface = sessaoInterface;
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
                    TempData["MensagemErro"] = "Credenciais inv�lidas";
                    return View(usuarioLoginDto);
                }

                // Criar uma sess�o com o usu�rio que se logou.
                _sessaoInterface.CriarSessao(usuario.Dados);

                TempData["MensagemSucesso"] = "Usu�rio logado!";
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
                    TempData["MensagemErro"] = "Ocorreu um erro ao reslizar o processo!";
                    return View(usuarioCriacaoDto);
                }

                TempData["MensagemSucesso"] = usuario.Mensagem;
                return RedirectToAction("Login");
            }
            else
            {
                return View(usuarioCriacaoDto);
            }
        }
    }
}
