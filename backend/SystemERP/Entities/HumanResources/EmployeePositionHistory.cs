using Entities.Common;

namespace Entities.HumanResources
{
    public class EmployeePositionHistory:BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = new Employee();

        public int PositionId { get; set; }
        public virtual Position Position { get; set; } = new Position();

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = new Department();

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
