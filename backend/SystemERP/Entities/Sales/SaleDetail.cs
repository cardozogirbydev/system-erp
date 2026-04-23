using Entities.Common;
using Entities.Inventory;

namespace Entities.Sales
{
    public class SaleDetail:BaseEntity
    {
        public int SaleHeaderId { get; set; }
        public virtual SaleHeader SaleHeader { get; set; } = new SaleHeader();

        public int ProductPresentationId { get; set; }
        public virtual ProductPresentation ProductPresentation { get; set; } = new ProductPresentation();

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
    }
}
