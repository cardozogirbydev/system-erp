using Entities.Common;
using Entities.Sales;

namespace Entities.Finances
{
    public class PaymentForm:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DaysToPay { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<SaleHeader> Sales { get; set; } = new List<SaleHeader>();
        public virtual ICollection<PurchaseHeader> Purchases { get; set; } = new List<PurchaseHeader>();
    }
}
