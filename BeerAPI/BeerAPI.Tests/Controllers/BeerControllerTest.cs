using System.Threading.Tasks;
using AutoFixture.Xunit2;
using BeerAPI.Controllers;
using BeerAPI.DTO;
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
        private readonly IBeerUpdater _BeerUpdater;

        private readonly BeerResult _BeerResult;
        private readonly BeerQueryResult _BeerQueryResult;
        private readonly BeerCommand _BeerCommand;

        private readonly BeersController _BeerController;

        public BeerControllerTest()
        {
            _BeerResult = new BeerResult(1,"","", null,"",0,"",0,null);
            _BeerQueryResult = new BeerQueryResult(null, true);
            _BeerCommand = new BeerCommand();

            _BeerFinder = Substitute.For<IBeerFinder>();
            _BeerFinder.FindById(Arg.Any<int>()).Returns(Task.FromResult(_BeerResult));
            _BeerFinder.FindByCriteria(Arg.Any<BeerQuery>()).Returns(Task.FromResult(_BeerQueryResult));

            _BeerUpdater = Substitute.For<IBeerUpdater>();
            _BeerController = new BeersController(_BeerFinder, _BeerUpdater);
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

        [Fact]
        public async Task Post_Calls_BeerUpdater_Create()
        {
            await _BeerController.Post(_BeerCommand);

            await _BeerUpdater.Received(1).Create(Arg.Any<CreateBeerCommand>());
        }

        [Theory, AutoData]
        public async Task Put_Calls_BeerUpdater_Create(int id)
        {
            await _BeerController.Put(id, _BeerCommand);

            await _BeerUpdater.Received(1).Update(Arg.Is<UpdateBeerCommand>(command => command.Id==id));
        }

        [Theory, AutoData]
        public async Task Delete_Calls_BeerUpdater_Delete(int query)
        {
            await _BeerController.Delete(query);

            await _BeerUpdater.Received(1).Delete(query);
        }
    }
}
