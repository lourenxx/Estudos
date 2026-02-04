using Estudos.Web.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly HttpClient _httpClient;
        public UsuarioController(ILogger<UsuarioController> logger, IHttpClientFactory factory, IConfiguration config)
        {
            _logger = logger;
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("usuario");
                var usuarios = await response.Content.ReadFromJsonAsync<IEnumerable<UsuarioDto>>();

                return Json(usuarios);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IActionResult> CadastrarUsuarios(UsuarioDto dto)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("usuario", dto);
                var result = response.IsSuccessStatusCode;

                if (!result)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Erro ao cadastrar usuário: {ErrorMessage}", errorMessage);
                }

                UsuarioDto? usuarioCriado = await response.Content.ReadFromJsonAsync<UsuarioDto>();

                return Ok(usuarioCriado);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"usuario/{id}");
                bool result = response.IsSuccessStatusCode;
                string mensagem = await response.Content.ReadAsStringAsync();

                if (!result)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Erro ao excluir usuário: {ErrorMessage}", errorMessage);
                }

                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
