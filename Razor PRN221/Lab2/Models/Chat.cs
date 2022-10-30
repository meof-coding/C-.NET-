using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class Chat
    {
        public Chat()
        {
            ChatMsgs = new HashSet<ChatMsg>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ChatMsg> ChatMsgs { get; set; }
    }
}
