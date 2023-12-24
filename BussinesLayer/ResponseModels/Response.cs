using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ResponseModels
{
    public class Response
    {
        public string Message { get; set; } = string.Empty;
        public ResponseStatus Status { get; set; }

        public Response()
        {

        }

        public Response(string message, ResponseStatus status)
        {
            Message = message;
            Status = status;
        }


        public static Response Successful(string? message)
        {
            return new Response(message ?? ResponseStatus.Successful.ToString(), ResponseStatus.Successful);
        }

        public static Response Warning(string? message)
        {
            return new Response(message ?? ResponseStatus.Warning.ToString(), ResponseStatus.Warning);
        }

        public static Response Error(string? message)
        {
            return new Response(message ?? ResponseStatus.Error.ToString(), ResponseStatus.Error);
        }
    }

    public class Response<T> : Response where T : class
    {
        public T? Data { get; set; }

        public Response()
        {

        }

        public Response(string message, ResponseStatus status) : base(message, status)
        {
        }

        public Response(string message, ResponseStatus status, T? data) : base(message, status)
        {
            Data = data;
        }

        public static Response<T> Successful(T data, string? message = null)
        {
            return new Response<T>()
            {
                Message = message ?? ResponseStatus.Successful.ToString(),
                Status = ResponseStatus.Successful,
                Data = data
            };
        }
        public static Response<T> Successful(string message, T data)
        {
            return Successful(data, message);
        }
        public static Response<T> Warning(string? message, T? data = null)
        {
            return new Response<T>()
            {
                Message = message ?? ResponseStatus.Warning.ToString(),
                Status = ResponseStatus.Warning,
                Data = data
            };
        }

        public static Response<T> Error(string? message, T? data = null)
        {
            return new Response<T>()
            {
                Message = message ?? ResponseStatus.Error.ToString(),
                Status = ResponseStatus.Error,
                Data = data
            };
        }
    }
}
