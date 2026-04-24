using Entities.Common;

namespace Entities.HumanResources
{
    public class Position:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = new Department();

        public virtual ICollection<EmployeePositionHistory> EmployeePositionHistory { get; set; } = new List<EmployeePositionHistory>();
    }
}
