using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
 
using Ecommerz.Server.StaticServies;
using Ecommerz.Server.UserService.DBcontext;
using Ecommerz.Server.UserService.DTO;
using Ecommerz.Server.UserService.Models;
using Ecommerz.Server.UserService.Services.Interface;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerz.Server.UserService.Services
{
    public class UserService : IUserServices  
    {
        private readonly UserDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        private readonly IConfiguration _configuration;
        public UserService(UserDbContext context , IHttpContextAccessor httpContextAccessor , IConfiguration configuration)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        

        public ServiceResult Authentication(UserLoginDTO userLoginDTO)
        {

            Console.WriteLine("Authentication");
            var user = _context.Users.FirstOrDefault(u => u.Email == userLoginDTO.email);
            if(user == null) return ServiceResult.ErrorResult("User Not Found");
            _httpContextAccessor.HttpContext.Session.SetString("Userid" , user.Id.ToString());
            _httpContextAccessor.HttpContext.Session.SetString("Username" , user.Name.ToString());
             return ServiceResult.SuccessResult(user.ToString());
        }

        public ServiceResult CheckSession()
        {

            Console.WriteLine("Check Session");
            var userId = _httpContextAccessor.HttpContext.Session.GetString("Userid");
            if(userId == null) return ServiceResult.ErrorResult("User Not Found");
             return ServiceResult.SuccessResult("User Found");
             
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult RegisterUser(UserRegisterDTO userRegisterDTO)
        {
             Console.WriteLine("Register User");
             if(_context.Users.Any(u => u.Email == userRegisterDTO.email)) return ServiceResult.ErrorResult("User Already Exists");

             var user = new User{

                 Email = userRegisterDTO.email,
                 PasswordHash = userRegisterDTO.password,
                 Name = userRegisterDTO.userName ,
                 
             };

             _context.Users.Add(user);
             _context.SaveChanges();
            return  ServiceResult.SuccessResult("User Created");
        }

        public void UpdateShippingInfo(int userId, ShippingInfoDto shippingInfoDto)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(User user){
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
         

        
    }
}