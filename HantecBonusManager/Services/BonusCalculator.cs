using HantecBonusManager.Models;


namespace HantecBonusManager.Services
{
    public class BonusCalculator : IBonusCalculator
    {
        // The bonus points per deal
        private const decimal PointsPerDeal = 0.5m;

        public BonusPoint CalculateBonus(Deal deal)
        {
            if (deal == null)
            {
                throw new ArgumentNullException(nameof(deal));
            }

            // Simple bonus calculation: points per deal
            decimal bonusAmount = 1 * PointsPerDeal;

            // Create a BonusPoint object
            var bonusPoint = new BonusPoint
            {
                Id = Guid.NewGuid().ToString(), // Generate a unique identifier
                Amount = bonusAmount
            };

            return bonusPoint;
        }
    }
}
