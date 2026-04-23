using Entities.Common;
using Entities.Security;

namespace Entities.HumanResources
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
        
        public virtual ICollection<EmployeePositionHistory> EmployeePositions { get; set; } = new List<EmployeePositionHistory>();
    }
}
