﻿using System;
using System.Collections.Generic;
using Northwind.Core.Contracts;
using Northwind.Core.Repositories;

namespace Northwind.Core.Models
{
    public partial class Category : IWithId, IReferenceData
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
