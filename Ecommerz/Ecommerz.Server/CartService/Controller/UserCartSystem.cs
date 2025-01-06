using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerz.Server.CartService.DTO;
using Ecommerz.Server.CartService.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerz.Server.CartService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCartSystem : ControllerBase
    {
        private readonly ICartItem _userServices;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public UserCartSystem(ICartItem userServices, IHttpContextAccessor httpContextAccessor)
        {
            _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        [HttpPost("AddCartItem")]
        
        public IActionResult AddCartItem([FromBody] AddCartItemDto addCartItemDto)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var userId = _httpContextAccessor.HttpContext.Session.GetString("Userid");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (userId == null) return Unauthorized("User is Not logged in ");
            var result = _userServices.AddCartItem(int.Parse(userId), addCartItemDto);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetCartItems")]
        
        public IActionResult GetCartItems(){
            var userId = _httpContextAccessor.HttpContext.Session.GetString("Userid");
            var result = _userServices.GetCartItems(int.Parse(userId));
            if (result.Success) return Ok(result.Data);
            return BadRequest(result);
        }
    }
}