using System.Net;
using Blog.Service.Common.Model;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Service.ApiService.Middlewear;

public class GlobalExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            Log.Error(e, "An unhandled exception occurred");
            await HandleExceptionAsync(context, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var errorResponse = Result.Failure(e.Message);

        var result = JsonConvert.SerializeObject(errorResponse);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode  = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(result);
    }
}