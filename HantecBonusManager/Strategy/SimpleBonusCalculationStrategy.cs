using HantecBonusManager.Models;

public class SimpleBonusCalculationStrategy : IBonusCalculationStrategy
{
    public BonusPoint CalculateBonus(Deal deal)
    {
        // Simple bonus calculation logic
        decimal bonusAmount = deal.DealCount * 0.5m;

        return new BonusPoint { Amount = bonusAmount };
    }
}
