
using Application.Common;
using Application.Common.Exceptions;
using System.Text.Json;

namespace Api.Middlewares
{
    public class GlobalErrorHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try { 
              
                next.Invoke(context);
                if (context.Response.StatusCode == 401)
                    throw new UnAuthorizedException("UnAuthorized");
            }
            catch(Exception e) {

                var response = JsonSerializer.Serialize(await Response.FailureAsync("Faild",e.Message));
                context.Response.ContentType = "application/json";
                context?.Response.WriteAsync(response);

            }
        }
    }
}
