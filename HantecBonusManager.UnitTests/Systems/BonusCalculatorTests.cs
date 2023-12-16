using HantecBonusManager.Models;
using HantecBonusManager.Services;

namespace HantecBonusManager.UnitTests.Systems
{
    public class BonusCalculatorTests
    {
        [Fact]
        public async void CalculateBonus_ShouldReturnCorrectBonus()
        {
            // Arrange
            var bonusCalculator = new BonusCalculator();
            var deal = new Deal { Id = 1 };

            // Act
            var result = await bonusCalculator.CalculateBonus(deal);

            // Assert
            Assert.NotNull(result);
        }
    }
}