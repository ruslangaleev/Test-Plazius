namespace TravelCard
{
    public interface IExample
    {
        TravelCard[] Sort(TravelCard[] cards);
    }

    public class Example : IExample
    {
        public TravelCard[] Sort(TravelCard[] cards)
        {
            throw new System.NotImplementedException();
        }
    }
}
