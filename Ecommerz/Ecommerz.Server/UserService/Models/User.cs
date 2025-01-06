using Ecommerz.Server.CartService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerz.Server.UserService.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public  string PasswordHash { get; set; }
        public List<Role> Roles { get; set; }
        public List<Cart> Carts { get; internal set; }
        public ShippingInfo shippingInfo { get; set; }
        
    }
}