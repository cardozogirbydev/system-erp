using Entities.Common;

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
    }
}
