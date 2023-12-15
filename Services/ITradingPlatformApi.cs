using HantecBonusManager.Models;

namespace HantecBonusManager.Services
{
    public interface ITradingPlatformApi
    {
        Task<List<Account>> GetAccountsList();
        Task<List<Deal>> GetHistoricalDeals(string accountId, DateTime fromDateTime, DateTime toDateTime);
        Task CreateCreditOperation(string accountId, decimal amount);
    }

}
