using HantecBonusManager.Models;

namespace HantecBonusManager.Data
{
    public interface IDealRepository
    {
        List<Deal> GetHistoricalDeals(long accountId, DateTime fromDate, DateTime toDate);
    }

    public class DealRepository : IDealRepository
    {
        private readonly DealsDbContext _dbContext;

        public DealRepository(DealsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Deal> GetHistoricalDeals(long accountId, DateTime fromDate, DateTime toDate)
        {
            return _dbContext.Deals
                .Where(deal => deal.AccountId == accountId && deal.Date >= fromDate && deal.Date <= toDate)
                .ToList();
        }
    }
}
