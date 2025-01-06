using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerz.Server.StaticServies
{
    public class ServiceResult
    {
        public bool  Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ServiceResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static ServiceResult SuccessResult(string message = null , object data = null) => new ServiceResult(true, message, data);
        public static ServiceResult ErrorResult(string message = null, object data = null) => new ServiceResult(false, message, data);

        
    }
}