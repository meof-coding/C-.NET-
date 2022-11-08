﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class UserRoom
    {
        [Column(Order = 0)]
        [Key]
        public int Id { get; set; }

        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Column(Order = 2)]
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        [Column(Order = 3)]
        public int Role { get; set; }
    }
}
