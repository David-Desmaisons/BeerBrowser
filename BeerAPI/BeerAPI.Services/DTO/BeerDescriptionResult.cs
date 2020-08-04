namespace BeerAPI.Services.DTO
{
    public class BeerDescriptionResult
    {
        public string Name { get; }
        public string PictureUrl { get; }
        public int Id { get; }

        public BeerDescriptionResult(int id, string name, string pictureUrl)
        {
            this.PictureUrl = pictureUrl;
            this.Id = id;
            this.Name = name;
        }
    }
}
