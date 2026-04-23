using Entities.Common;

namespace Entities.Inventory
{
    public class InventoryMovementReason:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int ActionType { get; set; }

        public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
    }
}
