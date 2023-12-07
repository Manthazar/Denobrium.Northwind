using Northwind.Core.Contracts;

namespace Northwind.Core.Models
{
    public partial class Region : IWithId, IReferenceData
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
