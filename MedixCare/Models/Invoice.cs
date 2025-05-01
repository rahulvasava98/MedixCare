using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedixCare.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; } 

        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Required, StringLength(20)]
        public string Status { get; set; } = "Pending";

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        public Appointment? Appointment { get; set; }
    }
}
