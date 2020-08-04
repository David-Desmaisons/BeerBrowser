using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerAPI.DTO;
using BeerAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientProvider _Provider;

        public IngredientsController(IIngredientProvider provider)
        {
            _Provider = provider;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IngredientResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<IngredientResult>> Get()
        {
            var data = await _Provider.GetAllIngredientsAsync();
            return data.Select(ing => new IngredientResult(ing.Id.Value, ing.Name));
        }
    }
}
