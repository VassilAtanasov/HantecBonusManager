using HantecBonusManager.Models;
using HantecBonusManager.Services;

namespace HantecBonusManager.UnitTests.Systems
{
    public class BonusCalculatorTests
    {
        [Fact]
        public void CalculateBonus_ShouldReturnCorrectBonus()
        {
            // Arrange
            var bonusCalculator = new BonusCalculator();
            var deal = new Deal { Id = 1 };

            // Act
            var result = bonusCalculator.CalculateBonus(deal);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0.5m, result.Amount);
        }
    }
}