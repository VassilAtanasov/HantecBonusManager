using HantecBonusManager.Models;

namespace HantecBonusManager.UnitTests.Fixtures
{
    public static class BonusManagerFixture
    {
        public static List<ProcessResults> ProcessResults => [
            new ProcessResults { AccountId = 1, Amount = 1 },
            new ProcessResults { AccountId = 2, Amount = 2 },
        ];
    }
}
