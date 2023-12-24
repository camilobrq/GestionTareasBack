using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ResponseModels
{
    public static class ResponseExtentions
    {
        public static Response<T> BuildSuccess<T>(this T data, string? message) where T : class
        {
            return Response<T>.Successful(message, data);
        }

        public static Response<T> BuildWarning<T>(this T? data, string? message) where T : class
        {
            return Response<T>.Warning(message, data);
        }

        public static Response<T> Error<T>(this T? data, string? message) where T : class
        {
            return Response<T>.Error(message, data);
        }
    }
}
