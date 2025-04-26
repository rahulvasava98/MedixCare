﻿using System.ComponentModel.DataAnnotations;

namespace MedixCare.Models
{
    public class CRMContact
    {
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string FirstName { get; set; }

        [Required,StringLength(50)]
        public string LastName { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required,Phone]
        public string Phone { get; set; }

    }
}
