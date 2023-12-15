using HantecBonusManager.Models;

namespace HantecBonusManager
{
    public interface IBonusManager
    {
        public Task<List<ProcessResults>> ProcessBonusForAccounts();
        
    }
}
