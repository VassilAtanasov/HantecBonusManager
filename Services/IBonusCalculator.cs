using HantecBonusManager.Models;

namespace HantecBonusManager.Services
{
    public interface IBonusCalculator
    {
        BonusPoint CalculateBonus(Deal deal);
    }
}