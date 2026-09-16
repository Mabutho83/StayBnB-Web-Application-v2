using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StayBnB_Web_Application_v2.Data;

namespace StayBnB_Web_Application_v2.Controllers
{
    //This controller is still incomplete and will be updated in the future.
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Lists all payments filtered by guest's id
        //for now, we will just list all payments
        public async Task<IActionResult> Index()
        {
           var payments = await _context.Payments.ToListAsync();
           return View(payments);
        }

        //GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments
                .Include(p => p.Booking)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

    }
}
