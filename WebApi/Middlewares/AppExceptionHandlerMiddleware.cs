using application.Exceptions;
using application.Wrappers;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public AppExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var errorResponse = new ApiResponse<string> { Suceeded = false, Message = ex.Message };
                switch (ex)
                {
                    case ApiExceptions e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationErrorException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorResponse.Errors = e.Errors;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(errorResponse);
                await response.WriteAsync(result);
            }
        }
    }
}
