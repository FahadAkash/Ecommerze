using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerz.Server.CartService.DTO;
using Ecommerz.Server.StaticServies;

namespace Ecommerz.Server.CartService.Services.Interface
{
    public interface ICartItem
    {
        public ServiceResult AddCartItem(int userId, AddCartItemDto addCartItemDto);
        public ServiceResult GetCartItems(int userId);

    }
}