using HantecBonusManager.Models;

namespace HantecBonusManager.Services
{
    public interface IBonusCalculator
    {
        Task<BonusPoint> CalculateBonus(Deal deal);
    }
}