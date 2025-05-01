using MedixCare.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedixCare.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Department = await _unitOfWork.Departments.GetAllAsync();
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
