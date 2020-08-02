namespace BeerAPI.DTO
{
    public class BeerQueryResult
    {
        public BeerQueryResult(BeerDescriptionResult[] results, bool remainingItems)
        {
            Results = results;
            RemainingItems = remainingItems;
        }

        public BeerDescriptionResult[] Results { get; }
        public bool RemainingItems { get; }
    }
}
