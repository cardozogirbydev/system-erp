using Entities.Common;

namespace Entities.Security
{
    public class RolePermission:BaseEntity
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = new Role();

        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; } = new Permission();
    }
}
