using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BeerAPI.Data.Entity;
using FluentAssertions;
using NHibernate;
using NHibernate.Criterion.Lambda;
using NSubstitute;
using Xunit;

namespace BeerAPI.Services.Tests
{
    public class IngredientProviderTest
    {
        private readonly IngredientProvider _IngredientProvider;
        private readonly ISession _Session;
        private readonly IQueryOver<Ingredient, Ingredient> _InicialQueryOver;
        private readonly IQueryOverOrderBuilder<Ingredient, Ingredient> _Ordered;

        private readonly IList<Ingredient> _Ingredients;

        public IngredientProviderTest()
        {
            _Ingredients = new []
            {
                new Ingredient(){Id = 1, Name ="z"},
                new Ingredient(){Id = 2, Name ="a"},
            };
            _Session = Substitute.For<ISession>();
            _InicialQueryOver = Substitute.For<IQueryOver<Ingredient, Ingredient>>();
            _InicialQueryOver.ListAsync().Returns(Task.FromResult(_Ingredients));
            _Ordered = new IQueryOverOrderBuilder<Ingredient, Ingredient>(_InicialQueryOver, p => p.Name);

            _Session.QueryOver<Ingredient>().Returns(_InicialQueryOver);
            _InicialQueryOver.OrderBy(Arg.Any<Expression<System.Func<Ingredient, object>>>()).Returns(_Ordered);

            _IngredientProvider = new IngredientProvider(_Session);
        }

        [Fact]
        public async Task GetAllIngredientsAsync_Calls_Session_QueryOver()
        {
            await _IngredientProvider.GetAllIngredientsAsync();

            _Session.Received(1).QueryOver<Ingredient>();
        }


        [Fact]
        public async Task GetAllIngredientsAsync_Calls_Session_QueryOver_OrderBy()
        {
            await _IngredientProvider.GetAllIngredientsAsync();

            _InicialQueryOver.Received(1).OrderBy(Arg.Any<Expression<System.Func<Ingredient, object>>>());
        }


        [Fact]
        public async Task GetAllIngredientsAsync_Returns_Ordered_List()
        {
            var expected = new List<Ingredient>
            {
                new Ingredient() {Id = 2, Name = "a"},
                new Ingredient() {Id = 1, Name = "z"}
            };

            var res = await _IngredientProvider.GetAllIngredientsAsync();

            res.Should().BeEquivalentTo(expected);
        }
    }
}
