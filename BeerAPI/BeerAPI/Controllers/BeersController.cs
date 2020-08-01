using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BeerResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BeerResult>>> Get([FromQuery] BeerQuery query)
        {
            return new []
            {
                new BeerResultBuilder().SetName("Fisher").Build()
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BeerResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BeerResult>> Get(int id)
        {
            return new BeerResultBuilder().SetName("Fisher").Build();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
