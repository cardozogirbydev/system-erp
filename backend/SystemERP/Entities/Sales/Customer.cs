using Entities.Common;

namespace Entities.Sales
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<SaleHeader> Sales { get; set; } = new List<SaleHeader>();
    }
}
