using ETrade.DtoLayer.IdentityDtos.LoginDtos;
using ETrade.WebUI.Models;
using ETrade.WebUI.Services.Abstracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ETrade.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto loginDto)
        {

            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto) 
        {
            signInDto.Username = "erkan02";
            signInDto.Password = "Erkan.65";
            await _identityService.SingIn(signInDto);
            return RedirectToAction("Index", "User");
        }
    }
}
