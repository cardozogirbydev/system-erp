using Entities.Common;

namespace Entities.HumanResources
{
    public class Department:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
        public virtual ICollection<EmployeePositionHistory> EmployeePositionHistory { get; set; } = new List<EmployeePositionHistory>();
    }
}
