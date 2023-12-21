namespace Northwind.Backoffice.Data
{
    public class EmployeeInfo
    {
        public string Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }

        public string ReportsToId { get; set; }
        public string ReportsToName { get; set; }

        public byte[] Photo { get; set; }

        public string PhotoPath { get; set; }

        public string PhotoFormat { get; set; } = "jpg"; // This is not supported by the current model. TODO: rework that part.
    }
}
