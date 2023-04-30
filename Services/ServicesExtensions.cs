namespace Lab2.Services
{
    public static class ServicesExtensions
    {
        public static void AddTimeService(this IServiceCollection services)
        {
            services.AddTransient<ITimeService, TimeService>();
        }
        public static void AddRandomService(this IServiceCollection services)
        {
            services.AddScoped<IRandomService, RandomService>();
        }
        public static void AddGeneralCounterService(this IServiceCollection services)
        {
            services.AddSingleton<IGeneralCounterService, GeneralCounterService>();
        }
    }
}
