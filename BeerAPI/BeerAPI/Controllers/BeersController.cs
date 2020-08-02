using System;
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
        [ProducesResponseType(typeof(BeerQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BeerQueryResult>> Get([FromQuery] BeerQuery query)
        {
            return new BeerQueryResult(new[]
            {
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"), new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"), new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
            }, false);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BeerResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BeerResult>> Get(int id)
        {
            return Bud(id);
        }

        private BeerResult Bud(int id=1)
        {
            return new BeerResultBuilder()
                .SetId(id)
                .SetName("Budweiser")
                .SetDescription("Só uma cerveja como a Budweiser consegue manter os 143 anos de história e, ao mesmo tempo, ter a autenticidade e liberdade para ser o que quiser. Ela não muda sua fórmula e nunca perde sua essência. Só Bud faz Bud.")
                .SetAlcoholPercentage(5)
                .SetHarmonization("O sabor marcante no começo e suave no final de Budweiser pede que ela harmonize com hambúrguer clássico, presunto cozido e mix de castanhas.")
                .SetMinTemperature(0)
                .SetMaxTemperature(4)
                .SetIngredients(new [] { "água", "malte", "arroz", "lúpulo" })
                .SetPictureUrl(@"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png")
                .SetColor(10)
                .Build();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] BeerResultBuilder value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BeerResultBuilder value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine($"Delete {id}");
        }
    }
}
