using HantecBonusManager.Models;
public class AdvancedBonusCalculationStrategy : IBonusCalculationStrategy
{
    public BonusPoint CalculateBonus(Deal deal)
    {
        // Advanced bonus calculation logic
        decimal bonusAmount = deal.DealCount * 0.5m;

        return new BonusPoint { Amount = bonusAmount };
    }
}
