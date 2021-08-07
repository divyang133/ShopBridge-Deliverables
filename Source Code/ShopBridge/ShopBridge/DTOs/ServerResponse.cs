using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.DTOs
{
    public class ServerResponse<T>
    {
        public ServerResponse(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
