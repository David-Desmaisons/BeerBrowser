using System.Threading.Tasks;
using BeerAPI.DTO;
using BeerAPI.Services;
using BeerAPI.Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeerFinder _BeerFinder;
        private readonly IBeerUpdater _BeerUpdater;

        public BeersController(IBeerFinder beerFinder, IBeerUpdater beerUpdater)
        {
            _BeerFinder = beerFinder;
            _BeerUpdater = beerUpdater;
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
        public async Task Post([FromForm] BeerCommand payload)
        {
            var information = payload.Transform();
            var command = new CreateBeerCommand(information);
            await _BeerUpdater.Create(command);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] BeerCommand payload)
        {
            var information = payload.Transform();
            var command = new UpdateBeerCommand(id, information);
            await _BeerUpdater.Update(command);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _BeerUpdater.Delete(id);
        }
    }
}
