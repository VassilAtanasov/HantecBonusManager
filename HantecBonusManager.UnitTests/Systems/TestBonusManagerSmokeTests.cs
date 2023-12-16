using FluentAssertions;
using HantecBonusManager.Models;
using HantecBonusManager.Services;
using Moq;
using Moq.Protected;

namespace HantecBonusManager.UnitTests
{
    public class TestBonusManager
    {
        [Fact]
        public async Task ProcessBonusForAccounts_OnSuccess_ReturnNotNull()
        {
            // Arrange
            var mockTradingPlatformApi = new Mock<ITradingPlatformApi>();
            var mockBonusCalculator = new Mock<IBonusCalculator>();

            var sut = new BonusManager(mockTradingPlatformApi.Object, mockBonusCalculator.Object);
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
            var mockBonusCalculator = new Mock<IBonusCalculator>();

            var sut = new BonusManager(mockTradingPlatformApi.Object, mockBonusCalculator.Object);
            // Act
            var result = await sut.ProcessBonusForAccounts();
            // Assert
            result.Should().BeOfType<List<ProcessResults>>();
        }
    }
}