namespace Lab2.Services
{
    public class RandomService : IRandomService
    {
        public int Number { get; }
        public RandomService()
        {
            Number = new Random().Next();
        }
    }
}
