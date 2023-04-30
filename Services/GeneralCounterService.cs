namespace Lab2.Services
{
    public class GeneralCounterService : IGeneralCounterService
    {
        public int _count;
        public void Increment()
        {
            _count++;
        }
        public int GetCount() => _count;
    }
}
