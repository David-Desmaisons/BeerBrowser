using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Data.Entity;
using NHibernate;

namespace BeerAPI.Services
{
    public class IngredientProvider : IIngredientProvider
    {
        private readonly ISession _Session;

        public IngredientProvider(ISession session)
        {
            _Session = session;
        }

        public Task<IList<Ingredient>> GetAllIngredients()
        {
            return _Session.QueryOver<Ingredient>().ListAsync<Ingredient>();
        }
    }
}
