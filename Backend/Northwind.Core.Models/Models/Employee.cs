﻿using Northwind.Core.Contracts;
using Northwind.Core.Repositories;

namespace Northwind.Core.Models
{
    public partial class Employee : IWithId, ICacheable
    {
        public Employee()
        {
            InverseReportsToNavigation = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            Territories = new HashSet<Territory>();
        }

        public int Id { get; set; }

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? HomePhone { get; set; }
        public string? Extension { get; set; }
        public string? Notes { get; set; }
        public int? ReportsToId { get; set; }

        /// <summary>
        /// A photo of the employee
        /// </summary>
        /// <remarks>
        /// The photo is a nice feature of northwind, but unfortunately, doesn't specify the format of it.
        /// </remarks>
        public byte[]? Photo { get; set; }
        public string? PhotoPath { get; set; }

        public virtual Employee? ReportsTo { get; set; }
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }

        public string GetFullName() => $"{LastName}, {FirstName}";
    }
}
