using Entities.Common;
using Entities.HumanResources;
using Entities.Purchases;
using Entities.Sales;

namespace Entities.Security
{
    public class User:BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<SaleHeader> Sales { get; set; } = new List<SaleHeader>();
        public virtual ICollection<PurchaseHeader> Purchases { get; set; } = new List<PurchaseHeader>();
    }
}
