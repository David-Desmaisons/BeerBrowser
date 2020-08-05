using BeerAPI.Data.Entity;
using BeerAPI.Services.DTO;
using BeerAPI.Services.Implementation;
using FluentAssertions;
using NHibernate;
using NHibernate.Criterion.Lambda;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Xunit;

namespace BeerAPI.Services.Tests.Implementation
{
    public class BeerFinderTest
    {
        private readonly ISession _Session;
        private readonly IQueryOver<Beer, Beer> _QueryOver;
        private readonly BeerQuery _BeerQuery;
        private readonly Beer _Found;

        private readonly BeerFinder _BeerFinder;

        public BeerFinderTest()
        {
            _Found = new Beer()
            {
                Id =89,
                Name = "Licher",
                Image = new byte[0]
            };
             _QueryOver = Substitute.For<IQueryOver<Beer, Beer>>();
            _QueryOver.Where(Arg.Any<Expression<System.Func<Beer, bool>>>()).Returns(_QueryOver);
            _QueryOver.And(Arg.Any<Expression<System.Func<Beer, bool>>>()).Returns(_QueryOver);
            _QueryOver.Skip(Arg.Any<int>()).Returns(_QueryOver);
            _QueryOver.Take(Arg.Any<int>()).Returns(_QueryOver);
            _QueryOver.OrderBy(Arg.Any<Expression<System.Func<Beer, object>>>()).Returns(arg => new IQueryOverOrderBuilder<Beer, Beer>(_QueryOver, arg[0] as Expression<System.Func<Beer, object>>));

            _Session = Substitute.For<ISession>();
            _Session.QueryOver<Beer>().Returns(_QueryOver);
            _Session.LoadAsync<Beer>(Arg.Any<int>()).Returns(Task.FromResult(_Found));

            _BeerFinder = new BeerFinder(_Session);
            _BeerQuery = new BeerQuery
            {
                AlcoholPercentage = new Range(),
                Color = new Range(),
                Temperature = new Range(),
                MaxItems = 20
            };
        }

        [Fact]
        public async Task FindByCriteria_Calls_Session_QueryOver_Beer()
        {
            await _BeerFinder.FindByCriteria(_BeerQuery);

            _Session.Received().QueryOver<Beer>();
        }

        [Fact]
        public async Task FindByCriteria_Compute_Done_Has_True_When_Done()
        {
            _QueryOver.ListAsync().Returns(Task.FromResult<IList<Beer>>(new[]
            {
                new Beer(){Id = 29, Name="douglas", Image = new byte[0]}
            }));
            var res = await _BeerFinder.FindByCriteria(_BeerQuery);

            res.Done.Should().BeTrue();
        }

        [Fact]
        public async Task FindByCriteria_Compute_Done_Has_False_When_Not_Done()
        {
            var list = Enumerable.Range(0, 40).Select(_ => new Beer() {Id = 29, Name = "douglas", Image = new byte[0]})
                .ToList();
            _QueryOver.ListAsync().Returns(Task.FromResult<IList<Beer>>(list));

            var res = await _BeerFinder.FindByCriteria(_BeerQuery);

            res.Done.Should().BeFalse();
        }

        [Theory,AutoData]
        public async Task FindById_Call_LoadAsync(int id)
        {
            await _BeerFinder.FindById(id);

            await _Session.Received(1).LoadAsync<Beer>(id);
        }

        [Theory, AutoData]
        public async Task FindById_CReturns_Correct_Id(int id)
        {
            var res = await _BeerFinder.FindById(id);

            res.Id.Should().Be(_Found.Id);
        }

        [Theory, AutoData]
        public async Task FindById_CReturns_Correct_Name(int id)
        {
            var res = await _BeerFinder.FindById(id);

            res.Name.Should().Be(_Found.Name);
        }
    }
}
