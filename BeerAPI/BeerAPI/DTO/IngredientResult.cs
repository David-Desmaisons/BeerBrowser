namespace BeerAPI.DTO
{
    public class IngredientResult
    {
        public string Name { get; }
        public int Id { get; }

        public IngredientResult(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
