using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ChatMsg? ChatMsg { get; set; }
    }
}
