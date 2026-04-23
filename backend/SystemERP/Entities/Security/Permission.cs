using Entities.Common;

namespace Entities.Security
{
    public class Permission:BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int ModuleId { get; set; }
        public virtual Module Module { get; set; } = new Module();

        public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
