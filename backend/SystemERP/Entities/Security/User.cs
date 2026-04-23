using Entities.Common;
using Entities.HumanResources;

namespace Entities.Security
{
    public class User:BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
