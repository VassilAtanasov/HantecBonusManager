using HantecBonusManager.Models;
using HantecBonusManager.Services;

namespace HantecBonusManager
{
    public class BonusManager(ITradingPlatformApi tradingPlatformApi, IBonusCalculator bonusCalculator) : IBonusManager
    {
        public async Task<List<ProcessResults>> ProcessBonusForAccounts()
        {
            var results = new List<ProcessResults>();
            var accounts = await tradingPlatformApi.GetAccountsList() ?? [];
            foreach (var account in accounts)
            {
                if (account is not null)
                {
                    List<Deal> deals = await tradingPlatformApi.GetHistoricalDeals(account.Id, DateTime.Now.AddMonths(-1), DateTime.Now);
                    decimal totalBonus = await CalculateTotalBonus(deals);

                    await tradingPlatformApi.CreateCreditOperation(account.Id, totalBonus);
                    results.Add(new ProcessResults() { AccountId = account.Id, Amount = totalBonus });
                }
            }

            return results;
        }

        private async Task<decimal> CalculateTotalBonus(List<Deal> deals)
        {
            decimal totalBonus = 0;

            foreach (var deal in deals ?? [])
            {
                BonusPoint bonus = await bonusCalculator.CalculateBonus(deal);
                totalBonus += bonus.Amount;
            }

            return totalBonus;
        }
    }
}
