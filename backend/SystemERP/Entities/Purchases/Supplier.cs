using Entities.Common;

namespace Entities.Purchases
{
    public class Supplier:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? TaxId { get; set; }
        public string? ContactName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<PurchaseHeader> Purchases { get; set; } = new List<PurchaseHeader>();
    }
}
