using Lab2.Middleware;
using Lab2.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddTimeService();
services.AddRandomService();
services.AddGeneralCounterService();
var app = builder.Build();
app.UseFileServer();
app.UseMiddleware<GeneralCounterMiddleware>();
app.UseWhen(context => context.Request.Path == "/services/timer", appBuilder =>
{
    appBuilder.UseMiddleware<TimeMiddleware>();
});
app.UseWhen(context => context.Request.Path == "/services/random", appBuilder =>
{
    appBuilder.UseMiddleware<RandomMiddleware>();
});
app.MapGet("/services/list", async (context) =>
{
    var sb = new StringBuilder();
    sb.Append($"<h1>All services ({services.Count})</h1><table>");
    sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Realization</th></tr>");
    foreach (var svc in services)
    {
        sb.Append("<tr>");
        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
        sb.Append($"<td>{svc.Lifetime}</td>");
        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
        sb.Append("</tr>");
    }
    sb.Append("</table>");
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());

});
app.Run();
