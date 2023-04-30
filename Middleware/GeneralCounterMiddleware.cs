using System.Net.Mime;
using Lab2.Services;

namespace Lab2.Middleware
{
    public class GeneralCounterMiddleware
    {
        public readonly RequestDelegate next;
        public GeneralCounterMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, IGeneralCounterService generalCounterService)
        {
            generalCounterService.Increment();
            if (context.Request.Path == "/services/general-counter")
            {
                await context.Response.WriteAsync($"Counter: {generalCounterService.GetCount()}");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
