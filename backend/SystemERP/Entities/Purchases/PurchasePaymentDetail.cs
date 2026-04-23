using Entities.Common;
using Entities.Finances;

namespace Entities.Purchases
{
    public class PurchasePaymentDetail:BaseEntity
    {
        public int PurchaseHeaderId { get; set; }
        public virtual PurchaseHeader PurchaseHeader { get; set; } = new PurchaseHeader();

        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; } = new PaymentMethod();

        public decimal Amount { get; set; }
        public string? Reference { get; set; }
    }
}
