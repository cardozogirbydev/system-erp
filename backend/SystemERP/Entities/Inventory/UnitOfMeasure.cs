using Entities.Common;

namespace Entities.Inventory
{
    public class UnitOfMeasure:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Abbreviation { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<ProductPresentation> ProductPresentations { get; set; } = new List<ProductPresentation>();
    }
}
