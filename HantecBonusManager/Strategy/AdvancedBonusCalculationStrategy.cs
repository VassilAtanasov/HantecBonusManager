using HantecBonusManager.Models;
public class AdvancedBonusCalculationStrategy : IBonusCalculationStrategy
{
    public BonusPoint CalculateBonus(Deal deal)
    {
        // Advanced bonus calculation logic
        decimal bonusAmount = deal.DealCount * 1.0m;

        return new BonusPoint { Amount = bonusAmount };
    }
}
