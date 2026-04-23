using Entities.Common;

namespace Entities.Inventory
{
    public class ProductStock:BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = new Product();

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = new Warehouse();

        public decimal Quantity { get; set; }
    }
}
