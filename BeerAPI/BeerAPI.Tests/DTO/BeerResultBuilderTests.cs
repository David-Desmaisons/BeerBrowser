using AutoFixture.Xunit2;
using BeerAPI.DTO;
using FluentAssertions;
using Xunit;

namespace BeerAPI.Tests.DTO
{
    public class BeerResultBuilderTests
    {
        private readonly BeerResultBuilder _BeerResultBuilder;

        public BeerResultBuilderTests()
        {
            _BeerResultBuilder = new BeerResultBuilder();
        }

        [Theory, AutoData]
        public void SetName_value_is_passed_to_build_object(string value)
        {
            var result = _BeerResultBuilder.SetName(value).Build();
            result.Name.Should().Be(value);
        }

        [Theory, AutoData]
        public void SetAlcoholPercentage_value_is_passed_to_build_object(decimal value)
        {
            var result = _BeerResultBuilder.SetAlcoholPercentage(value).Build();
            result.AlcoholPercentage.Should().Be(value);
        }

        //TODO add more tests here
    }
}
