using FluentAssertions;
using HantecBonusManager.Models;
using HantecBonusManager.Services;
using Moq;

namespace HantecBonusManager.UnitTests
{
    public class TestBonusManagerSmokeTests
    {
        [Fact]
        public async Task ProcessBonusForAccounts_OnSuccess_ReturnNotNull()
        {
            // Arrange
            var mockTradingPlatformApi = new Mock<ITradingPlatformApi>();
            var simpleBonusCalculationStrategy = new Mock<SimpleBonusCalculationStrategy>();

            var sut = new BonusManager(mockTradingPlatformApi.Object, simpleBonusCalculationStrategy.Object);
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

            var sut = new BonusManager(mockTradingPlatformApi.Object, simpleBonusCalculationStrategy.Object);
            // Act
            var result = await sut.ProcessBonusForAccounts();
            // Assert
            result.Should().BeOfType<List<ProcessResults>>();
        }
    }
}