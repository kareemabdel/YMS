using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Core.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse() { }
        public ApiResponse(HttpStatusCode statusCode, T data, dynamic errors)
        {
            Errors = errors;
            StatusCode = statusCode;
            Data = data;
        }

        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public dynamic Errors { get; set; }
    }
}
