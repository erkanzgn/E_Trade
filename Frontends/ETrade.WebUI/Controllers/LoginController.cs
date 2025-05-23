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
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
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
            if (!ModelState.IsValid)
                return View(loginDto);

            var result = await _identityService.SingIn(new SignInDto
            {
                Username = loginDto.UserName,
                Password = loginDto.Password
            });

            if (!result)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                return View(loginDto);
            }

            return RedirectToAction("Index", "Default");
        }


        //[HttpPost]
        //public async Task<IActionResult> Index(CreateLoginDto loginDto)
        //{

        //    return View();
        //}

    }
}
