using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Synonymous.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Synonymous.Middleware
{
    public class SynonymExceptionHandler
    {
        private readonly RequestDelegate _next;
        public SynonymExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = "error";
            var statusCode = HttpStatusCode.BadRequest;
            var exceptionType = exception.GetType();
            switch (exception)
            {
                case Exception e when exceptionType == typeof(UnauthorizedAccessException):
                    statusCode = HttpStatusCode.Unauthorized;
                    errorCode = "Unauthorized Access";
                    break;

                case SynonymException e when exceptionType == typeof(SynonymException):
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = e.Message;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    errorCode = "Something went wrong. Please contact support.";
                    break;
            }

            var response = new { code = statusCode, message = errorCode };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(payload);

        }
    }
}
