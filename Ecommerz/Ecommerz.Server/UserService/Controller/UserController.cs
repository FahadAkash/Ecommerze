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
        public UserController(IUserServices userServices){
            _userServices = userServices;
        }

        [HttpPost]
        public  Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO userRegisterDTO)  {
            if(userRegisterDTO == null) return Task.FromResult<IActionResult>(BadRequest());
            var result =  _userServices.RegisterUser(userRegisterDTO);
            return Task.FromResult<IActionResult>(Ok(result));
        } 

        [HttpPost("login")]
        public  Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLoginDTO)  {
            if(userLoginDTO == null) return Task.FromResult<IActionResult>(BadRequest());
            var result =  _userServices.Authentication(userLoginDTO);
            return Task.FromResult<IActionResult>(Ok(result));
        }
        
        
    }
}