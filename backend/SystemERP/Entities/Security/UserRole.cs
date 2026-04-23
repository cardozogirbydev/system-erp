using Entities.Common;

namespace Entities.Security
{
    public class UserRole:BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = new User();

        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = new Role();
    }
}
