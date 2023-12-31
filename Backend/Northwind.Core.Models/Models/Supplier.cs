﻿using Northwind.Core.Contracts;

namespace Northwind.Core.Models
{
    public partial class Supplier : IWithId
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }

        /// <summary>
        /// An encoded string of the homepage with dash (#) as separator
        /// </summary>
        /// <example>
        /// Name of link#http#
        /// </example>
        public string? HomePage { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
