using Entities.Common;
using Entities.Purchases;
using Entities.Sales;

namespace Entities.Finances
{
    public class PaymentMethod:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<SalePaymentDetail> SalePaymentDetails { get; set; } = new List<SalePaymentDetail>();
        public virtual ICollection<PurchasePaymentDetail> PurchasePaymentDetails { get; set; } = new List<PurchasePaymentDetail>();
    }
}
