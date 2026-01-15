using Estudos.Web.DTO;
using Estudos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Estudos.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory, IConfiguration config)
        {
            _logger = logger;
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                var response = await _httpClient.GetAsync("usuario");
                var usuarios = await response.Content.ReadFromJsonAsync<IEnumerable<UsuarioDto>>();

                return Json(usuarios);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
