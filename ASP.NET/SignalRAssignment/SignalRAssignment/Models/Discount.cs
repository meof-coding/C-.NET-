using System;
using System.Collections.Generic;

#nullable disable

namespace SignalRAssignment.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? DiscountPercent { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime ExperiedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
