using HantecBonusManager.Models;

namespace HantecBonusManager.Services
{
    public interface ITradingPlatformApi
    {
        Task<List<Account>> GetAccountsList();
        Task<List<Deal>> GetHistoricalDeals(long accountId, DateTime fromDateTime, DateTime toDateTime);
        Task CreateCreditOperation(long accountId, decimal amount);
    }
}
