namespace Northwind.Api.Data
{
    public record SupplierInfo
    {
        public string Id { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; } = null!;

        public string? ContactTitle { get; set; } = null!;

        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? HomePage { get; set; }
    }
}
