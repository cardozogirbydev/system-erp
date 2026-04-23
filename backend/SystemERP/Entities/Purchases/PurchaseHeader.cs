using Entities.Common;
using Entities.Finances;
using Entities.Security;

namespace Entities.Purchases
{
    public class PurchaseHeader:BaseEntity
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal Total { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = new Supplier();

        public int UserId { get; set; }
        public virtual User User { get; set; } = new User();

        public int PaymentFormId { get; set; }
        public virtual PaymentForm PaymentForm { get; set; } = new PaymentForm();

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
        public virtual ICollection<PurchasePaymentDetail> PurchasePaymentDetails { get; set; } = new List<PurchasePaymentDetail>();
    }
}
