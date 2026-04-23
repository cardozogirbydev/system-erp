using Entities.Common;

namespace Entities.Security
{
    public class AuditLog:BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = new User();

        public string EntityName { get; set; } = string.Empty;
        public int EntityId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string OldValues { get; set; } = string.Empty;
        public string NewValues { get; set; } = string.Empty;
    }
}
