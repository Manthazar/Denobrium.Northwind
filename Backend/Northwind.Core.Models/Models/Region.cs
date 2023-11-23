namespace Northwind.Core.Models
{
    public partial class Region : IWithId
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public int Id { get; set; }
        public string RegionDescription { get; set; } = null!;

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
