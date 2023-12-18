using HantecBonusManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HantecBonusManager.Data
{
    public class DealsDbContext(DbContextOptions<DealsDbContext> options) : DbContext(options)
    {
        public DbSet<Deal> Deals { get; set; }
    }
}
