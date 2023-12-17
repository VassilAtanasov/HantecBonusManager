using HantecBonusManager.Models;

public interface IBonusCalculationStrategy
{
    BonusPoint CalculateBonus(Deal deal);
}
