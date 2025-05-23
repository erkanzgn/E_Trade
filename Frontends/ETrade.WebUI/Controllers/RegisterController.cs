﻿using ETrade.DtoLayer.IdentityDtos.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ETrade.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createRegisterDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("API Hata Mesajı: " + responseContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            return View();
        }
    }
}
