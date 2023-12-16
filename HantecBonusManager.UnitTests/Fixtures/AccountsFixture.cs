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
            new Deal { Id = 1 },
            new Deal { Id = 2 },    
        ];
    }
}
