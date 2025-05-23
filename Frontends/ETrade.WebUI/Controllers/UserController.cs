﻿using ETrade.WebUI.Services.Abstracts;
using ETrade.WebUI.Services.CargoServices.CargoCustomerServices;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
       
        }

        public async  Task<IActionResult> Index()
        {
            var values=await _userService.GetUserInfo();
            return View(values);
        }

    }
}
