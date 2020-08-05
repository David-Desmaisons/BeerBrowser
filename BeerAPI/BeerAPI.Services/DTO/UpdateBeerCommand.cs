namespace BeerAPI.Services.DTO
{
    public class UpdateBeerCommand
    {
        public int Id { get; }
        public BeerInformation Information { get; }

        public UpdateBeerCommand(int id, BeerInformation information)
        {
            Information = information;
            Id = id;
        }
    }
}
