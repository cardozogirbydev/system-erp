using Entities.Common;
using Entities.Finances;
using Entities.Security;

namespace Entities.Sales
{
    public class SaleHeader:BaseEntity
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = new Customer();

        public int UserId { get; set; }
        public virtual User User { get; set; } = new User();

        public int PaymentFormId { get; set; }
        public virtual PaymentForm PaymentForm { get; set; } = new PaymentForm();

        public virtual ICollection<SaleDetail> SaleDetail { get; set; } = new List<SaleDetail>();
        public virtual ICollection<SalePaymentDetail> SalePaymentDetail { get; set; } = new List<SalePaymentDetail>();
    }
}
