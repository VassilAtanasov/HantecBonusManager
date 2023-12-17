using HantecBonusManager.Models;

namespace HantecBonusManager.UnitTests.Systems
{

    public class BonusCalculationStrategyTests
    {
        [Fact]
        public void CalculateBonus_OnSimpleBonusCalculationStrategy_ShouldReturnCorrectBonus()
        {
            // Arrange
            var simpleBonusCalculationStrategy = new SimpleBonusCalculationStrategy();
            var deal = new Deal { DealCount = 5 };

            // Act
            var result = simpleBonusCalculationStrategy.CalculateBonus(deal);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2.5m, result.Amount); // Assuming a simple calculation logic: 5 deals * 0.5 bonus points per deal
        }


        [Fact]
        public void CalculateBonus_OnAdvancedBonusCalculationStrategy_ShouldReturnCorrectBonus()
        {
            // Arrange
            var advancedBonusCalculationStrategy = new AdvancedBonusCalculationStrategy();
            var deal = new Deal { DealCount = 7 };

            // Act
            var result = advancedBonusCalculationStrategy.CalculateBonus(deal);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(7.0m, result.Amount); // Assuming an advanced calculation logic: 7 deals * 1.0 bonus points per deal
        }
    }
}
