﻿using MedixCare.DTOs;

namespace MedixCare.ViewModels.ForTry
{
    public class AdminDashboardViewModel
    {
        public int TotalPatients { get; set; }
        public int TotalDoctors { get; set; }

        public List<AppointmentDTO> UpcomingAppointments { get; set; }
    }
}
