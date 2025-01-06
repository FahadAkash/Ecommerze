using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerz.Server.UserService.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int CartID { get; set; }
        public Cart Cart { get; set; }
    }
}