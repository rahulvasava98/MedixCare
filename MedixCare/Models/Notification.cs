using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedixCare.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Recipient))]
        public string RecipientId { get; set; }

        public ApplicationUser? Recipient { get; set; }
    }
}
