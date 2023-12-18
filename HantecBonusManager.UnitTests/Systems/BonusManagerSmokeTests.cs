using FluentAssertions;
using HantecBonusManager.Data;
using HantecBonusManager.Models;
using HantecBonusManager.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace HantecBonusManager.UnitTests
{
    public class BonusManagerSmokeTests
    {
        [Fact]
        public async Task ProcessBonusForAccounts_OnSuccess_ReturnNotNull()
        {
            // Arrange
            var mockTradingPlatformApi = new Mock<ITradingPlatformApi>();
            var simpleBonusCalculationStrategy = new Mock<SimpleBonusCalculationStrategy>();

            var mockDealRepository = new Mock<IDealRepository>();
            var mockLogger = new Mock<ILogger<BonusManager>>();

            var sut = new BonusManager(mockTradingPlatformApi.Object, simpleBonusCalculationStrategy.Object, mockDealRepository.Object, mockLogger.Object);
            // Act
            var result = await sut.ProcessBonusForAccounts();
            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ProcessBonusForAccounts_OnEmptyAccountList_ReturnEmptyListOfProcessResults()
        {
            // Arrange
            var mockTradingPlatformApi = new Mock<ITradingPlatformApi>();
            var simpleBonusCalculationStrategy = new Mock<SimpleBonusCalculationStrategy>();

            var mockDealRepository = new Mock<IDealRepository>();
            var mockLogger = new Mock<ILogger<BonusManager>>();

            var sut = new BonusManager(mockTradingPlatformApi.Object, simpleBonusCalculationStrategy.Object, mockDealRepository.Object, mockLogger.Object);
            // Act
            var result = await sut.ProcessBonusForAccounts();
            // Assert
            result.Should().BeOfType<List<ProcessResults>>();
        }
    }
}