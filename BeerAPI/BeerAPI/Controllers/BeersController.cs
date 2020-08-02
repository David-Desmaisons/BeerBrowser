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
                Bud()
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BeerResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BeerResult>> Get(int id)
        {
            return Bud();
        }

        private BeerResult Bud()
        {
            return new BeerResultBuilder()
                .SetId(1)
                .SetName("Budweiser")
                .SetDescription("Só uma cerveja como a Budweiser consegue manter os 143 anos de história e, ao mesmo tempo, ter a autenticidade e liberdade para ser o que quiser. Ela não muda sua fórmula e nunca perde sua essência. Só Bud faz Bud.")
                .SetAlcoholPercentage(5)
                .SetHarmonization("O sabor marcante no começo e suave no final de Budweiser pede que ela harmonize com hambúrguer clássico, presunto cozido e mix de castanhas.")
                .SetMinTemperature(0)
                .SetMaxTemperature(4)
                .SetIngredients("Água, malte, arroz e lúpulo.")
                .SetPictureUrl(@"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png")
                .SetColor(10)
                .Build();
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
