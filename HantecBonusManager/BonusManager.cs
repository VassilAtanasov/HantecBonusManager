using HantecBonusManager.Models;
using HantecBonusManager.Services;
using System.Diagnostics;

namespace HantecBonusManager
{
    public class BonusManager: IBonusManager
    {
        private readonly ITradingPlatformApi _tradingPlatformApi;
        private readonly BonusCalculator _bonusCalculator;

        public BonusManager(ITradingPlatformApi tradingPlatformApi, IBonusCalculationStrategy bonusCalculationStrategy)
        {
            _tradingPlatformApi = tradingPlatformApi;
            _bonusCalculator = new BonusCalculator(bonusCalculationStrategy);
        }

        public async Task<List<ProcessResults>> ProcessBonusForAccounts()
        {
            var results = new List<ProcessResults>();
            var accounts = await _tradingPlatformApi.GetAccountsList() ?? [];
            foreach (var account in accounts)
            {
                if (account is not null)
                {
                    List<Deal> deals = await _tradingPlatformApi.GetHistoricalDeals(account.Id, DateTime.Now.AddMonths(-1), DateTime.Now);
                    decimal totalBonus = CalculateTotalBonus(deals);
                    try
                    {
                        await _tradingPlatformApi.CreateCreditOperation(account.Id, totalBonus);
                        results.Add(new ProcessResults() { AccountId = account.Id, Amount = totalBonus });
                    }
                    catch (Exception e){
                        Debug.Print(e.Message);
                    }
                }
            }

            return results;
        }

        private decimal CalculateTotalBonus(List<Deal> deals)
        {
            decimal totalBonus = 0;

            foreach (var deal in deals ?? [])
            {
                BonusPoint bonus = _bonusCalculator.CalculateBonus(deal);
                totalBonus += bonus.Amount;
            }

            return totalBonus;
        }
    }
}
