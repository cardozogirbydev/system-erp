using Entities.Common;

namespace Entities.Inventory
{
    public class InventoryMovement:BaseEntity
    {
        public int ProductPresentationId { get; set; }
        public virtual ProductPresentation ProductPresentation { get; set; } = new ProductPresentation();

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = new Warehouse();

        public int InventoryMovementReasonId { get; set; }
        public virtual InventoryMovementReason InventoryMovementReason { get; set; } = new InventoryMovementReason();

        public decimal Quantity { get; set; }
        public string? Observation { get; set; }
    }
}