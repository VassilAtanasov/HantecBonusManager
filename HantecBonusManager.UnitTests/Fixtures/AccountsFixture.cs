using HantecBonusManager.Models;

namespace HantecBonusManager.UnitTests.Fixtures
{
    public static class TradingApiFixtures
    {
        public static List<Account> Accounts => [
            new Account { Id = 1 },
            new Account { Id = 2 },
        ];

        public static List<Deal> HistoricDeals => [
            new Deal { AccountId = 1 },
            new Deal { AccountId = 2 },    
        ];
    }
}
