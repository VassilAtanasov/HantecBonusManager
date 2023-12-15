using HantecBonusManager.Models;

namespace HantecBonusManager
{
    public interface IBonusManager
    {
        List<ProcessResults> ProcessBonusForAccounts();
        
    }
}
