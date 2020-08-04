using System.Threading.Tasks;
using BeerAPI.Services.DTO;

namespace BeerAPI.Services
{
    public class BeerFinder : IBeerFinder
    {
        public async Task<BeerQueryResult> FindByCriteria(BeerQuery query)
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
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
                new BeerDescriptionResult(1, "Budweiser",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png"),
                new BeerDescriptionResult(2, "beck's",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/becks_330ml.png"),
                new BeerDescriptionResult(3, "Bohemia Imperial",
                    @"https://www.ambev.com.br/conteudo/uploads/2019/03/bohemia-imperial_550ml.png"),
            }, false);
        }

        public async Task<BeerResult> FindById(int id)
        {
            return Bud(id);
        }

        private BeerResult Bud(int id = 1)
        {
            return new BeerResultBuilder()
                .SetId(id)
                .SetName("Budweiser")
                .SetDescription("Só uma cerveja como a Budweiser consegue manter os 143 anos de história e, ao mesmo tempo, ter a autenticidade e liberdade para ser o que quiser. Ela não muda sua fórmula e nunca perde sua essência. Só Bud faz Bud.")
                .SetAlcoholPercentage(5)
                .SetHarmonization("O sabor marcante no começo e suave no final de Budweiser pede que ela harmonize com hambúrguer clássico, presunto cozido e mix de castanhas.")
                .SetTemperature(new Range(0, 4))
                .SetIngredients(new[] { "água", "malte", "arroz", "lúpulo" })
                .SetPictureUrl(@"https://www.ambev.com.br/conteudo/uploads/2019/03/budweiser_600ml.png")
                .SetColor(10)
                .Build();
        }
    }
}
