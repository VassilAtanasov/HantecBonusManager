using HantecBonusManager.Data;
using HantecBonusManager.Models;
using HantecBonusManager.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

public class DealRepositoryTests
{
    [Fact]
    public void GetHistoricalDeals_ShouldReturnDealsFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DealsDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new DealsDbContext(options))
        {
            // Seed some test data into the in-memory database
            context.Database.EnsureDeleted();
            context.Deals.Add(new Deal { AccountId = 1, Date = DateTime.Now, Amount = 100.0m });
            context.Deals.Add(new Deal { AccountId = 2, Date = DateTime.Now, Amount = 150.0m });
            context.SaveChanges();
        }

        using (var context = new DealsDbContext(options))
        {
            var mockTradingPlatformApi = new Mock<ITradingPlatformApi>();
            var dealRepository = new DealRepository(context);

            // Act
            var result = dealRepository.GetHistoricalDeals(1, DateTime.Now.AddMonths(-1), DateTime.Now);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Expecting one deal for account "1" based on the test data
            Assert.Equal(1, result[0].AccountId);
        }
    }

    [Fact]
    public void AddDeals_ShouldAddDealsToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DealsDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new DealsDbContext(options))
        {
            context.Database.EnsureDeleted();
            var dealRepository = new DealRepository(context);

            var dealsToAdd = new List<Deal>
            {
                new Deal { AccountId = 1, Date = DateTime.Now, Amount = 100.0m },
                new Deal { AccountId = 2, Date = DateTime.Now, Amount = 150.0m },
                // Add more deals as needed
            };

            // Act
            dealRepository.AddDeals(dealsToAdd);

            // Assert
            Assert.Equal(dealsToAdd.Count, context.Deals.Count());

            foreach (var deal in dealsToAdd)
            {
                var addedDeal = context.Deals.Find(deal.Id);
                Assert.NotNull(addedDeal);
                Assert.Equal(deal.AccountId, addedDeal.AccountId);
            }
        }
    }

}
