using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Ecommerz.Server.StaticServies;
using Ecommerz.Server.UserService.DTO;
using Ecommerz.Server.UserService.Models;

namespace Ecommerz.Server.UserService.Services.Interface
{
    public interface IUserServices
    {
        ServiceResult RegisterUser(UserRegisterDTO userRegisterDTO);
        ServiceResult Authentication(UserLoginDTO userLoginDTO);
        User GetUserById(int id);
        void UpdateShippingInfo(int userId , ShippingInfoDto shippingInfoDto);    
        ServiceResult CheckSession();
       
    }
}