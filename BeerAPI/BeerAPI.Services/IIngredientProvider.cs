using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Data.Entity;

namespace BeerAPI.Services
{
    public interface IIngredientProvider
    {
        Task<IList<Ingredient>> GetAllIngredientsAsync();
    }
}
