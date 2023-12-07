using Northwind.Core.Contracts;

namespace Northwind.Core.Models
{
    public partial class Territory : IReferenceData, IWithId, IWithCode
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string TerritoryDescription { get; set; } = null!;
        public int RegionId { get; set; }

        public virtual Region Region { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
