using Entities.Common;

namespace Entities.Inventory
{
    public class Warehouse:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public virtual ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();
    }
}
