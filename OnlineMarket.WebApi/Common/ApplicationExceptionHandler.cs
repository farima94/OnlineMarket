using Newtonsoft.Json;
using OnlineMarket.Domain.Exceptions.GeneralExceptions;

namespace OnlineMarket.WebApi.Common;

public class ApplicationExceptionHandler
{
    private readonly RequestDelegate _next;

    public ApplicationExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApplicationExceptionBase ex)
        {
            Console.WriteLine(ex);
            context.Response.StatusCode = (int) ex.HttpStatusCode;
            var result = new {message = ex.Message};
            var strResult = JsonConvert.SerializeObject(result);
            await context.Response.WriteAsync(strResult);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            var result = new {message = "خطایی رخ داده است"};
            var strResult = JsonConvert.SerializeObject(result);
            await context.Response.WriteAsync(strResult);
        }
    }
}