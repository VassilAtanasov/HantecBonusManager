using HantecBonusManager.Models;

namespace HantecBonusManager.Services
{
    public interface ITradingPlatformApi
    {
        List<Account> GetAccountsList();
        List<Deal> GetHistoricalDeals(string accountId, DateTime fromDateTime, DateTime toDateTime);
        void CreateCreditOperation(string accountId, decimal amount);
    }

}
