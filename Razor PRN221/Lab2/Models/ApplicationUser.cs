using Lab2.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public string Avatar { get; set; }
         
        [InverseProperty("FromUser")]
        public virtual ICollection<Message> FromUser { get; set; }

        [InverseProperty("ToUser")]
        public virtual ICollection<Message> ToUser { get; set; }

        public virtual ICollection<UserRoom> UserRoom { get; set; }

        [NotMapped]
        public string ConnectionId { get; set; }
    }
}
