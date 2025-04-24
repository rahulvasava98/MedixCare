﻿namespace MedixCare.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

    }


}
