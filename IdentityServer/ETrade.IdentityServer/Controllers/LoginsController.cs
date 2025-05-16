﻿using ETrade.IdentityServer.Dtos;
using ETrade.IdentityServer.Models;
using ETrade.IdentityServer.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETrade.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin (UserLoginDto userLoginDto)
        {
            var result =await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password,false,false);
            var user =await _userManager.FindByNameAsync(userLoginDto.UserName);
            if (result.Succeeded)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.UserName = userLoginDto.UserName;
                model.Id = user.Id;
                var token=JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
            {
                return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
            }
        }


    }
}
