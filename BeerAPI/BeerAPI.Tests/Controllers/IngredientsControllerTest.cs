using BeerAPI.Controllers;
using BeerAPI.Services;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerAPI.Data.Entity;
using BeerAPI.DTO;
using FluentAssertions;
using Xunit;

namespace BeerAPI.Tests.Controllers
{
    public class IngredientsControllerTest
    {
        private readonly IIngredientProvider _IIngredientProvider;
        private readonly IngredientsController _IngredientsController;
        private IList<Ingredient> _Ingredients;

        public IngredientsControllerTest()
        {
            _Ingredients = new[]
            {
                new Ingredient() {Id = 1, Name = "agua"},
                new Ingredient() {Id = 2, Name = "lúpulo"}
            };

            _IIngredientProvider = Substitute.For<IIngredientProvider>();

            _IIngredientProvider.GetAllIngredientsAsync().Returns(Task.FromResult(_Ingredients));

            _IngredientsController = new IngredientsController(_IIngredientProvider);

        }

        [Fact]
        public async Task Get_Calls_GetAllIngredientsAsync()
        {
            await _IngredientsController.Get();

            await _IIngredientProvider.Received().GetAllIngredientsAsync();
        }

        [Fact]
        public async Task Get_Returns_Expected_Values()
        {
            var res = await _IngredientsController.Get();

            res.Should().BeEquivalentTo(new []
            {
                new IngredientResult(1, "agua"),
                new IngredientResult(2, "lúpulo")
            });
        }
    }
}
