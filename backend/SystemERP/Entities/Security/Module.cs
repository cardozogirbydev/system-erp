using Entities.Common;

namespace Entities.Security
{
    public class Module:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
