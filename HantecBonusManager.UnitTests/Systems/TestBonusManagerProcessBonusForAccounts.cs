using FluentAssertions;
using HantecBonusManager.Models;
using HantecBonusManager.Services;
using HantecBonusManager.UnitTests.Fixtures;
using Moq;
using Moq.Protected;

namespace HantecBonusManager.UnitTests.Systems
{
    public class TestBonusManagerProcessBonusForAccounts
    {
        [Fact]
        public async Task ProcessBonusForAccounts_OnAccountList_ReturnListOfProcessResults()
        {
            // Arrange
            var mockTradingPlatformApi = new Mock<ITradingPlatformApi>();
            mockTradingPlatformApi.
                Setup(m => m.GetAccountsList())
                .ReturnsAsync(TradingApiFixtures.Accounts);

            mockTradingPlatformApi.
                Setup(m => m.GetHistoricalDeals(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(TradingApiFixtures.HistoricDeals);

            mockTradingPlatformApi.
                Setup(m => m.CreateCreditOperation(It.IsAny<long>(), It.IsAny<decimal>()));

            var mockBonusCalculator = new Mock<IBonusCalculator>();
            mockBonusCalculator
                .Setup(m => m.CalculateBonus(It.IsAny<Deal>()))
                .ReturnsAsync(new BonusPoint() { Amount = 1 });

            var sut = new BonusManager(mockTradingPlatformApi.Object, mockBonusCalculator.Object);

            // Act
            var result = await sut.ProcessBonusForAccounts();

            // Assert
            result.Should().BeOfType<List<ProcessResults>>();
            mockTradingPlatformApi.Verify(m => m.GetAccountsList(), Times.Once);
            mockTradingPlatformApi.Verify(m => m.GetHistoricalDeals(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()),
                Times.Exactly(2));
            mockBonusCalculator.Verify(m => m.CalculateBonus(It.IsAny<Deal>()), Times.Exactly(4));
            mockTradingPlatformApi.Verify(m => m.CreateCreditOperation(It.IsAny<long>(), It.IsAny<decimal>()), Times.Exactly(2));
        }
    }
}