using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using BeerAPI.Data.Entity;
using BeerAPI.Services.DTO;
using BeerAPI.Services.Implementation;
using NHibernate;
using NSubstitute;
using Xunit;

namespace BeerAPI.Services.Tests.Implementation
{
    public class BeerUpdaterTest
    {
        private readonly ISession _Session;

        private readonly BeerUpdater _BeerUpdater;
        private readonly CreateBeerCommand _CreateBeerCommand;
        private readonly BeerInformation _BeerInformation;
        private readonly Beer _Beer;

        public BeerUpdaterTest()
        {
            _Session = Substitute.For<ISession>();
            _Beer = new Beer();
            _Session.LoadAsync<Beer>(Arg.Any<int>()).Returns(Task.FromResult(_Beer));
            _BeerInformation = new BeerInformation("name","d","h",12,22,
                new Range(10,20),new []{"agua", "lupulo"},new byte[0],  "png");
            _CreateBeerCommand = new CreateBeerCommand(_BeerInformation);

            _BeerUpdater = new BeerUpdater(_Session);
        }

        [Theory, AutoData]
        public async Task Delete_Call_Delete(int beerId)
        {
            await _BeerUpdater.Delete(beerId);

            await _Session.Received(1).DeleteAsync(Arg.Is<Beer>(obj => _Beer == obj));
        }

        [Theory, AutoData]
        public async Task Delete_Call_Load(int beerId)
        {
            await _BeerUpdater.Delete(beerId);

            await _Session.Received(1).LoadAsync<Beer>(beerId);
        }

        [Theory, AutoData]
        public async Task Update_Call_Load(int beerId)
        {
            var updateBeerCommand = new UpdateBeerCommand(beerId, _BeerInformation);

            await _BeerUpdater.Update(updateBeerCommand);

            await _Session.Received(1).LoadAsync<Beer>(beerId);
        }


        [Theory, AutoData]
        public async Task Update_Call_Save(int beerId)
        {
            var updateBeerCommand = new UpdateBeerCommand(beerId, _BeerInformation);

            await _BeerUpdater.Update(updateBeerCommand);

            await _Session.Received(1).UpdateAsync(Arg.Is<Beer>(b => b == _Beer), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Create_Call_Save()
        {

            await _BeerUpdater.Create(_CreateBeerCommand);

            await _Session.Received(1).SaveAsync(Arg.Is<Beer>(b => b.Name == _BeerInformation.Name), Arg.Any<CancellationToken>());
        }
    }
}
