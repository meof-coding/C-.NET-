using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class ChatMsg
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string? LineMsg { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Chat Chat { get; set; } = null!;
        public virtual User IdNavigation { get; set; } = null!;
    }
}
