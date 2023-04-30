using Lab2.Services;

namespace Lab2.Middleware
{
    public class RandomMiddleware
    {
        public readonly RequestDelegate next;
        public RandomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, IRandomService randomService)
        {
            await context.Response.WriteAsync($"Random: {randomService.Number}\nRandom: {randomService.Number}");
        }
    }
}
