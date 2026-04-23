using Entities.Common;

namespace Entities.Inventory
{
    public class Product:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string BaseSKU { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = new Category();

        public virtual ICollection<ProductPresentation> ProductPresentations { get; set; } = new List<ProductPresentation>();
        public virtual ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();
    }
}
