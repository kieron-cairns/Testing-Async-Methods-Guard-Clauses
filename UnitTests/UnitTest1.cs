using AutoFixture;
using AutoFixture.Idioms;
using AutoFixture.Kernel;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingAsyncMethodsGuardClauses.Models;
using TestingAsyncMethodsGuardClauses.Queries;
using TestingAsyncMethodsGuardClauses.Repositories;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetStockItemsById_Is_Gaurded_Against_Null_Args()
        {
          
            //Arrange
            var fixture = new Fixture();
            var assertion = fixture.Create<GuardClauseAssertion>();

            fixture.Customizations.Add(
                new TypeRelay(
                    typeof(TestingAsyncMethodsGuardClauses.Repositories.IStockRepository),
                    typeof(TestingAsyncMethodsGuardClauses.Repositories.StockRepository)));

            //Act & Assert
            assertion.Verify(typeof(StockQueryService).GetMethod(nameof(StockQueryService.GetStockItemById))); 
        }

        [Fact]
        public async Task GetStockItemById_Returns_Collection_Of_Stock_Item()
        {
            //Arrange
            var testBuilder = new TestFixtureBuilder();

            var expected = new List<StockItem>()
            {
                new StockItem {Id = 1, Name = "MacBook Pro 13inch", Quantity = 10, Price = 1300.0}
            };

            int expectedId = 1;
            string expectedName = "MacBook Pro 13inch";

            //Act
            var sut = testBuilder.WithStockItemList(expected, 1).BuildSut();

            var result = await sut.GetStockItemById(1);

            //Assert
            result.Should().BeOfType<List<StockItem>>();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(expectedId);
            result[0].Name.Should().Be(expectedName);
        }

        private class TestFixtureBuilder
        {
            public Fixture Fixture;
            public Mock<IStockRepository> mockStockRepository;

            public TestFixtureBuilder()
            {
                this.Fixture = new Fixture();
                this.mockStockRepository = new Mock<IStockRepository>();    
            }

            public StockQueryService BuildSut()
            {
                return new StockQueryService(this.mockStockRepository.Object);
            }

            public TestFixtureBuilder WithStockItemList(List<StockItem> stockItems, int id)
            {
                var mockStockItemList = new Mock<Task<List<StockItem>>>();

                this.mockStockRepository.Setup(x => x.GetStockItemById(id)).Returns(Task.FromResult(stockItems));
                return this;
            }
        }
    }
}