using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerz.Server.Model;
using Ecommerz.Server.StaticServies;
using Ecommerz.Server.UserService.DTO;
using Ecommerz.Server.UserService.Services.Interface;

namespace Ecommerz.Server.UserService.Services
{
    public class UserService : IUserServices  
    {
        
        public ServiceResult Authentication(UserLoginDTO userLoginDTO)
        {

            Console.WriteLine("Authentication");
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult RegisterUser(UserRegisterDTO userRegisterDTO)
        {
             Console.WriteLine("Register User");
            return  ServiceResult.SuccessResult("User Created");
        }

        public void UpdateShippingInfo(int userId, ShippingInfoDto shippingInfoDto)
        {
            throw new NotImplementedException();
        }
    }
}