using HantecBonusManager.Models;


namespace HantecBonusManager.Services
{
    public class BonusCalculator : IBonusCalculator
    {
        private readonly IBonusCalculationStrategy _bonusCalculationStrategy;

        public BonusCalculator(IBonusCalculationStrategy bonusCalculationStrategy)
        {
            _bonusCalculationStrategy = bonusCalculationStrategy;
        }

        public BonusPoint CalculateBonus(Deal deal)
        {
            return _bonusCalculationStrategy.CalculateBonus(deal);
        }
    }

}
