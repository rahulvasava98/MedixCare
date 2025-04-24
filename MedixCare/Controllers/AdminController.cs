using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedixCare.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            //var patientCount = await _context.Patients.CountAsync();
            //var doctorCount = await _context.Doctors.CountAsync();
            //var upcomingAppointments = await _context.Appointments
            //    .Where(a => a.Date >= DateTime.Now)
            //    .OrderBy(a => a.Date)
            //    .Take(5)
            //    .ToListAsync();

            //var viewModel = new AdminDashboardViewModel
            //{
            //    PatientCount = patientCount,
            //    DoctorCount = doctorCount,
            //    UpcomingAppointments = upcomingAppointments
            //};
            //return View(viewModel);
            return View(); 
        }
    }
}
