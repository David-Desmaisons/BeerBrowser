namespace BeerAPI.Services.DTO
{
    public class CreateBeerCommand
    {
        public CreateBeerCommand(BeerInformation information)
        {
            Information = information;
        }

        public BeerInformation Information { get; }
    }
}
