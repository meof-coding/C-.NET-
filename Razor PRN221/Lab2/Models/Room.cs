using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public virtual ApplicationUser UserAccount { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<UserRoom> UserRoom { get; set; }
    }
}
