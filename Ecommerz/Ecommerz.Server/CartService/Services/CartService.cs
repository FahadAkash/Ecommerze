using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerz.Server.CartService.DTO;
using Ecommerz.Server.CartService.Models;
using Ecommerz.Server.CartService.Services.Interface;
using Ecommerz.Server.StaticServies;
using Ecommerz.Server.UserService.DBcontext;
using Microsoft.EntityFrameworkCore;

namespace Ecommerz.Server.CartService.Services
{
    public class CartService : ICartItem
    {
        private readonly UserDbContext _context;
        public CartService(UserDbContext context)
        {
            _context = context;
        }

        public ServiceResult AddCartItem(int userId, AddCartItemDto addCartItemDto)
        {

            var cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>(),

                };
                _context.Carts.Add(cart);

                var cartItem = new CartItem
                {
                    ProductID = addCartItemDto.ProductID,
                    Quantity = addCartItemDto.Quantity,
                    Price = addCartItemDto.Price,
                    Cart = cart



                };
                cart.CartItems.Add(cartItem);
                _context.SaveChanges();
                return ServiceResult.SuccessResult("Item added to Cart " + cartItem.ToString());
            }
            return ServiceResult.ErrorResult("Cart Not Found");

        }
        public ServiceResult GetCartItems(int userId){
            var cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.UserId == userId);
            if (cart == null) return ServiceResult.ErrorResult("Cart Not Found");
            return ServiceResult.SuccessResult("Cart Retrived successfully." , cart.CartItems[0].Price);
        }


    }
}