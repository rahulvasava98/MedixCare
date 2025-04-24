using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedixCare.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Dashboard() {
        //    var staffTasks = await _context.Tasks
        //.Where(t => t.Status == "Pending")
        //.ToListAsync();

        //    return View(staffTasks);

            return View();
        }
    }
}
