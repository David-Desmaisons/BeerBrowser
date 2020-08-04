using System.Threading.Tasks;
using BeerAPI.Services;
using BeerAPI.Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BeerCommand = BeerAPI.DTO.BeerCommand;

namespace BeerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeerFinder _BeerFinder;

        public BeersController(IBeerFinder beerFinder)
        {
            _BeerFinder = beerFinder;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BeerQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BeerQueryResult>> Get([FromQuery] BeerQuery query)
        {
            return await _BeerFinder.FindByCriteria(query);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BeerResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BeerResult>> Get(int id)
        {
            return await _BeerFinder.FindById(id);
        }

        [HttpPost]
        public void Post([FromForm] BeerCommand payload)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromForm] BeerCommand value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
