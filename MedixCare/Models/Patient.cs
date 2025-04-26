﻿using System.ComponentModel.DataAnnotations;

namespace MedixCare.Models
{
    public class Patient
    {
        public int Id { get; set; }


        [Required,StringLength(50)]
        public string FirstName { get; set; }

        [Required,StringLength(50)]
        public string LastName { get; set; }

        public string? ProfileImage { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }


    }
}
