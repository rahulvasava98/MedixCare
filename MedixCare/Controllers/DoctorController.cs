using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedixCare.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            //var doctor = await _userManager.GetUserAsync(User);
            //var upcomingAppointments = await _context.Appointments
            //    .Where(a => a.DoctorId == doctor.Id && a.Date >= DateTime.Now)
            //    .OrderBy(a => a.Date)
            //    .ToListAsync();

            //return View(upcomingAppointments);

            return View();
        }
    }
}
