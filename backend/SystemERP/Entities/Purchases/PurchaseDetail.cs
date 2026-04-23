using Entities.Common;
using Entities.Inventory;

namespace Entities.Purchases
{
    public class PurchaseDetail:BaseEntity
    {
        public int PurchaseHeaderId { get; set; }
        public virtual PurchaseHeader PurchaseHeader { get; set; } = new PurchaseHeader();

        public int ProductPresentationId { get; set; }
        public virtual ProductPresentation ProductPresentation { get; set; } = new ProductPresentation();

        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
    }
}
