using HantecBonusManager.Models;
using HantecBonusManager.Services;
using Moq;

namespace HantecBonusManager.UnitTests.Systems
{
    public class BonusCalculatorTests
    {
        [Fact]
        public void CalculateBonus_ShouldReturnCorrectBonus()
        {
            // Arrange
            var mockSimpleBonusCalculationStrategy = new Mock<IBonusCalculationStrategy>();
            var bonusCalculator = new BonusCalculator(mockSimpleBonusCalculationStrategy.Object);

            var deal = new Deal { Id = 1, DealCount=5 };
            var expectedBonusPoint = new BonusPoint { Amount = 2.5m }; // Assuming a simple calculation logic: 5 deals * 0.5 bonus points per deal

            mockSimpleBonusCalculationStrategy.Setup(strategy => strategy.CalculateBonus(deal)).Returns(expectedBonusPoint);

            // Act
            var result = bonusCalculator.CalculateBonus(deal);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBonusPoint, result);
        }
    }
}