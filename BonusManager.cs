using HantecBonusManager.Models;
using HantecBonusManager.Services;

namespace HantecBonusManager
{
    public class BonusManager() : IBonusManager
    {
        public async Task<List<ProcessResults>> ProcessBonusForAccounts()
        {
            return new List<ProcessResults>();
        }
    }
}
