using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerz.Server.UserService.DTO;
using Ecommerz.Server.UserService.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerz.Server.UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;   
        private readonly IHttpContextAccessor? _httpContextAccessor;
        public UserController(IUserServices userServices , IHttpContextAccessor httpContextAccessor){
            _userServices = userServices;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("register")]
        public  Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO userRegisterDTO)  {
            if(userRegisterDTO == null) return Task.FromResult<IActionResult>(BadRequest());
            var result =  _userServices.RegisterUser(userRegisterDTO);
            return Task.FromResult<IActionResult>(Ok(result));
        } 
        [HttpPost("logout")]
        public IActionResult LogoutUser()  {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _httpContextAccessor.HttpContext.Session.Clear();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(new {message = "User Logged Out"});
        }

        [HttpPost("login")]
        public  Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLoginDTO)  {
            if(userLoginDTO == null) return Task.FromResult<IActionResult>(BadRequest());
            var result =  _userServices.Authentication(userLoginDTO);
            return Task.FromResult<IActionResult>(Ok(result));
        }
        [HttpPost("Check Session")]
        public Task<IActionResult> CheckSession()  {
            var result =  _userServices.CheckSession();
            return Task.FromResult<IActionResult>(Ok(result));
        }
        
        
    }
}