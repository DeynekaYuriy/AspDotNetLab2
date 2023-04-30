using Lab2.Services;

namespace Lab2.Middleware
{
    public class TimeMiddleware
    {
        public readonly RequestDelegate next;
        public TimeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, ITimeService timeService)
        {
            await context.Response.WriteAsync($"Date and time: {timeService?.GetDateTime()}");
        }
    }
}
