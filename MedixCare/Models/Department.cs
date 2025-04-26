using System.ComponentModel.DataAnnotations;

namespace MedixCare.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required,StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }    

        public string? Image { get; set; }

        public ICollection<Doctor>? Doctors { get; set; }

    }
}
