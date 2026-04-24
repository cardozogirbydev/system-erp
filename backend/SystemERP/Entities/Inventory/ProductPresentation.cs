using Entities.Common;
using Entities.Purchases;
using Entities.Sales;

namespace Entities.Inventory
{
    public class ProductPresentation:BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = new Product();

        public int UnitOfMeasureId { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; } = new UnitOfMeasure();

        public string PresentationSKU { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal ConversionFactor { get; set; }
        public bool IsBaseUnit { get; set; }

        public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
    }
}
