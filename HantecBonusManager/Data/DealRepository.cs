using HantecBonusManager.Models;

namespace HantecBonusManager.Data
{
    public interface IDealRepository
    {
        List<Deal> GetHistoricalDeals(long accountId, DateTime fromDate, DateTime toDate);
        void AddDeals(List<Deal> deals); // New method for adding a list of deals
    }

    public class DealRepository(DealsDbContext dbContext) : IDealRepository
    {
        private readonly DealsDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public List<Deal> GetHistoricalDeals(long accountId, DateTime fromDate, DateTime toDate)
        {
            return _dbContext.Deals
                .Where(deal => deal.AccountId == accountId && deal.Date >= fromDate && deal.Date <= toDate)
                .ToList();
        }

        public void AddDeals(List<Deal> deals)
        {
            _dbContext.Deals.AddRange(deals);
            _dbContext.SaveChanges();
        }
    }
}
