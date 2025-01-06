using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerz.Server.UserService.Models
{
    public class Cart
    {
        public int CartId { get; set; } 
        public int UserId { get; set; } 
        public User User { get; set; }
        public List<CartItem> CartItems { get; set; }   
    }
}