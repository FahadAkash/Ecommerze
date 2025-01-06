using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerz.Server.UserService.DTO
{
    public class UserRegisterDTO
    {
        
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }    
    }
}