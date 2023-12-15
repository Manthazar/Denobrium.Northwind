namespace Northwind.Api.Data
{
    public class EmployeeInfo
    {
        public string Id { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }

        public string ReportsToId { get; set; } = null!;
        public string ReportsToName { get; set; } = null!;

        public byte[]? Photo { get; set; }

        //public string PhotoFormat { get; set; } = "jpg";

        public string? PhotoPath { get; set; }
    }
}
