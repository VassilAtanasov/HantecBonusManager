using HantecBonusManager.Data;
using HantecBonusManager.Models;
using HantecBonusManager.Services;
using Microsoft.Extensions.Logging;

namespace HantecBonusManager
{
    public class BonusManager(ITradingPlatformApi tradingPlatformApi,
        IBonusCalculationStrategy bonusCalculationStrategy,
        IDealRepository dealRepository,
        ILogger<BonusManager> logger) : IBonusManager
    {
        private readonly ITradingPlatformApi _tradingPlatformApi = tradingPlatformApi ?? throw new ArgumentNullException(nameof(tradingPlatformApi));
        private readonly BonusCalculator _bonusCalculator = new(bonusCalculationStrategy ?? throw new ArgumentNullException(nameof(bonusCalculationStrategy)));
        private readonly IDealRepository _dealRepository = dealRepository ?? throw new ArgumentNullException(nameof(dealRepository));
        private readonly ILogger<BonusManager> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<List<ProcessResults>> ProcessBonusForAccounts()
        {
            var results = new List<ProcessResults>();
            var accounts = await _tradingPlatformApi.GetAccountsList() ?? [];
            foreach (var account in accounts)
            {
                if (account is not null)
                {
                    try
                    {
                        List<Deal> deals = _dealRepository.GetHistoricalDeals(account.Id, DateTime.Now.AddMonths(-1), DateTime.Now);

                        decimal totalBonus = CalculateTotalBonus(deals);

                        await _tradingPlatformApi.CreateCreditOperation(account.Id, totalBonus);
                        results.Add(new ProcessResults() { AccountId = account.Id, Amount = totalBonus });
                        LogSuccess(account.Id, totalBonus);
                    }
                    catch (Exception ex)
                    {
                        LogError(account.Id, ex.Message);
                    }
                }
            }

            return results;
        }

        public async Task StoreHistoricalDealsInRepository(long accountId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<Deal> deals = await _tradingPlatformApi.GetHistoricalDeals(accountId, fromDate, toDate);
                _dealRepository.AddDeals(deals);

                LogSuccess(accountId, deals.Count);
            }
            catch (Exception ex)
            {
                LogError(accountId, ex.Message);
            }
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


        private void LogSuccess(long accountId, decimal totalBonus)
        {
            _logger.LogInformation($"Successfully credited bonus to account {accountId}. Total Bonus: {totalBonus}");
        }

        private void LogError(long accountId, string errorMessage)
        {
            _logger.LogError($"Error crediting bonus to account {accountId}. Error: {errorMessage}");
        }
    }
}
