namespace BeerAPI.Services.DTO
{
    public class BeerQueryResult
    {
        public BeerQueryResult(BeerDescriptionResult[] results, bool done)
        {
            Results = results;
            Done = done;
        }

        public BeerDescriptionResult[] Results { get; }
        public bool Done { get; }
    }
}
