using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IngredientResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<IngredientResult>> Get()
        {
            return new[]
            {
                new IngredientResult(1, "água"),
                new IngredientResult(1, "ovo"),
                new IngredientResult(1, "malte"),
                new IngredientResult(1, "lúpulo"),
                new IngredientResult(1, "arroz")
            };
        }
    }
}
