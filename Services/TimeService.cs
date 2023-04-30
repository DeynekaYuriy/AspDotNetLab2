namespace Lab2.Services
{
    public class TimeService : ITimeService
    {
        public string GetDateTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
