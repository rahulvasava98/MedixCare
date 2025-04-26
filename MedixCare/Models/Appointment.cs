using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedixCare.Models
{
    public class Appointment
    {
        public int id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required, StringLength(20)]
        public string status { get; set; } = "Scheduled";

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public Doctor? Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public Patient? Patient { get; set; }

        public Invoice? Invoice { get; set; }
    }
}
