
namespace HantecBonusManager.Models
{
    public class Deal
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long DealCount { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get;  set; }
    }
}
