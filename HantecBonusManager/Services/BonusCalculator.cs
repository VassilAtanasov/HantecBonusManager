using HantecBonusManager.Models;


namespace HantecBonusManager.Services
{
    public class BonusCalculator(IBonusCalculationStrategy bonusCalculationStrategy) : IBonusCalculator
    {
        private readonly IBonusCalculationStrategy _bonusCalculationStrategy = bonusCalculationStrategy;

        public BonusPoint CalculateBonus(Deal deal)
        {
            return _bonusCalculationStrategy.CalculateBonus(deal);
        }
    }

}
