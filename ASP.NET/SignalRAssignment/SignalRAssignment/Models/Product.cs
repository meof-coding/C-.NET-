﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SignalRAssignment.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public int? DiscountId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
