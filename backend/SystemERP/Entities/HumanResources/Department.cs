using Entities.Common;

namespace Entities.HumanResources
{
    public class Department:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
    }
}
