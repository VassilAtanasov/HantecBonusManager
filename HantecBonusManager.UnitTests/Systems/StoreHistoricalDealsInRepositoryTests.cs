using HantecBonusManager.Data;
using HantecBonusManager.Models;
using HantecBonusManager.Services;
using HantecBonusManager.UnitTests.Fixtures;
using Microsoft.Extensions.Logging;
using Moq;

namespace HantecBonusManager.UnitTests.Systems
{
    public class StoreHistoricalDealsInRepositoryTests
    {

        [Fact]
        public async Task StoreHistoricalDealsInRepository_ShouldAddDealsToRepository()
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
                Setup(m => m.CreateCreditOperation(It.IsAny<long>(), It.IsAny<decimal>()))
                .Throws(new ArgumentException());

            var simpleBonusCalculationStrategy = new Mock<IBonusCalculationStrategy>();
            simpleBonusCalculationStrategy
                .Setup(m => m.CalculateBonus(It.IsAny<Deal>()))
                .Returns(new BonusPoint() { Amount = 1 });

            var mockDealRepository = new Mock<IDealRepository>();
            mockDealRepository
                .Setup(m => m.GetHistoricalDeals(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(TradingApiFixtures.HistoricDeals);

            var mockLogger = new Mock<ILogger<BonusManager>>();

            var accountId = 1;
            var fromDate = DateTime.Now.AddMonths(-3);
            var toDate = DateTime.Now;

            var sut = new BonusManager(mockTradingPlatformApi.Object, simpleBonusCalculationStrategy.Object, mockDealRepository.Object, mockLogger.Object);

            // Act
            await sut.StoreHistoricalDealsInRepository(accountId, fromDate, toDate);;

            // Assert
            mockTradingPlatformApi.Verify(m => m.GetHistoricalDeals(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()),
                Times.Exactly(1));
            mockDealRepository.Verify(m => m.AddDeals(It.IsAny<List<Deal>>()),Times.Exactly(1));
        }
    }
}