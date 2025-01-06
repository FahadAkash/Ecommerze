using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerz.Server.UserService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public  string PasswordHash { get; set; }
        public List<Role> Roles { get; set; }
        public List<Cart> Carts { get; internal set; }
        public ShippingInfo shippingInfo { get; set; }
        
    }
}