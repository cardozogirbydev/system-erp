using Entities.Common;
using Entities.Finances;

namespace Entities.Sales
{
    public class SalePaymentDetail:BaseEntity
    {
        public int SaleHeaderId { get; set; }
        public virtual SaleHeader SaleHeader { get; set; } = new SaleHeader();

        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; } = new PaymentMethod();

        public decimal Amount { get; set; }
        public string? Reference { get; set; }
    }
}
