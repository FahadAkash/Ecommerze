using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerz.Server.UserService.Models;

namespace Ecommerz.Server.OrderService.Models
{
    public class ShippingInfo
    {
        public int ShippingInfoID { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public int userId { get; set; }
        public  User? User { get; set; }
        
    }
}