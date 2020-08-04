using System.Threading.Tasks;
using AutoFixture.Xunit2;
using BeerAPI.Controllers;
using BeerAPI.Services;
using BeerAPI.Services.DTO;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace BeerAPI.Tests.Controllers
{
    public class BeerControllerTest
    {
        private readonly IBeerFinder _BeerFinder;
        private readonly BeersController _BeerController;
        private readonly BeerResult _BeerResult;
        private readonly BeerQueryResult _BeerQueryResult;

        public BeerControllerTest()
        {
            _BeerResult = new BeerResult(1,"","", null,"",0,"",0,null);
            _BeerQueryResult = new BeerQueryResult(null, true);

            _BeerFinder = Substitute.For<IBeerFinder>();
            _BeerFinder.FindById(Arg.Any<int>()).Returns(Task.FromResult(_BeerResult));
            _BeerFinder.FindByCriteria(Arg.Any<BeerQuery>()).Returns(Task.FromResult(_BeerQueryResult));

            _BeerController = new BeersController(_BeerFinder);
        }

        [Theory,AutoData]
        public async Task Get_Id_Calls_BeerFinder_FindById(int id)
        {
            await _BeerController.Get(id);

            await _BeerFinder.Received(1).FindById(id);
        }

        [Theory, AutoData]
        public async Task Get_Id_Returns_BeerFinder_Result(int id)
        {
            var res = await _BeerController.Get(id);

            res.Value.Should().Be(_BeerResult);
        }

        [Theory, AutoData]
        public async Task Get_Query_Calls_BeerFinder_FindByCriteria(BeerQuery query)
        {
            await _BeerController.Get(query);

            await _BeerFinder.Received(1).FindByCriteria(query);
        }

        [Theory, AutoData]
        public async Task Get_Query_Returns_BeerFinder_Result(BeerQuery query)
        {
            var res = await _BeerController.Get(query);

            res.Value.Should().Be(_BeerQueryResult);
        }
    }
}
