using HantecBonusManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HantecBonusManager.Data
{
    public class DealsDbContext : DbContext
    {
        public DealsDbContext(DbContextOptions<DealsDbContext> options) : base(options)
        {
        }

        public DbSet<Deal> Deals { get; set; }
    }
}
