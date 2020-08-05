using System.Linq;
using System.Threading.Tasks;
using BeerAPI.Data.Entity;
using BeerAPI.Services.DTO;
using NHibernate;

namespace BeerAPI.Services.Implementation
{
    public class BeerFinder : IBeerFinder
    {
        private readonly ISession _Session;

        public BeerFinder(ISession session)
        {
            _Session = session;
        }

        public async Task<BeerQueryResult> FindByCriteria(BeerQuery query)
        {
            var beers = await BuildQuery(query).ListAsync();
            var done = beers.Count < query.MaxItems;
            var beersDto = beers.Select(TransformToDescription);
            return new BeerQueryResult(beersDto.ToArray(), done);
        }

        private IQueryOver<Beer> BuildQuery(BeerQuery query)
        {
            var result = _Session.QueryOver<Beer>()
                .Where(beer => !(beer.MinTemperature > query.Temperature.Max && beer.MaxTemperature < query.Temperature.Min))
                .And(beer => beer.Color >= query.Color.Min && beer.Color <= query.Color.Max)
                .And(beer => beer.AlcoholPercentage >= query.AlcoholPercentage.Min && beer.AlcoholPercentage <= query.AlcoholPercentage.Max);
            if (!string.IsNullOrEmpty(query.Name))
            {
                result = result.WhereRestrictionOn(x => x.Name).IsLike($"%{query.Name}%");
            }

            if (query.IngredientId == null)
            {
                return result.OrderBy(b => b.Name).Asc
                    .Skip(query.Skip)
                    .Take(query.MaxItems);
            }

            return result.JoinQueryOver<Ingredient>(b => b.Ingredients)
                    .Where(ig => ig.Id == query.IngredientId)
                    .OrderBy(b => b.Name).Asc
                    .Skip(query.Skip)
                    .Take(query.MaxItems);
        }

        public async Task<BeerResult> FindById(int id)
        {
            var beer = await _Session.LoadAsync<Beer>(id);
            return Transform(beer);
        }

        private static BeerDescriptionResult TransformToDescription(Beer beer)
        {
            var imageUrl = BuildImageFromFile(beer.Image);
            return new BeerDescriptionResult(beer.Id.Value, beer.Name, imageUrl);
        }

        private static BeerResult Transform(Beer beer)
        {
            var imageUrl = BuildImageFromFile(beer.Image);
            return new BeerResultBuilder()
                .SetId(beer.Id.Value)
                .SetName(beer.Name)
                .SetDescription(beer.Description)
                .SetHarmonization(beer.Harmonization)
                .SetAlcoholPercentage(beer.AlcoholPercentage)
                .SetColor(beer.Color)
                .SetTemperature(new Range(beer.MinTemperature, beer.MaxTemperature))
                .SetIngredients(beer.Ingredients.Select(ing => ing.Name).ToArray())
                .SetPictureUrl(imageUrl)
                .Build(); ;
        }

        private static string BuildImageFromFile(byte[] file)
        {
            return "";
        }
    }
}
