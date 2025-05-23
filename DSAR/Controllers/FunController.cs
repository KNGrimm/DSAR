using DSAR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSAR.Controllers
{
    public class FunController : Controller
    {
        private readonly AppDbContext _context;
        public FunController(AppDbContext context)
        {
            _context = context;
        }
        // GET: FunController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public async Task<ActionResult> Insert()
        {

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == userId.Value);
            return View(user);
        }
        public async Task<ActionResult> list()
        {
            var students = await _context.User.ToListAsync(); // Fetch all students
            return View(); // Pass data to the view for printing
        }
        // GET: FunController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FunController/Create
        // ===========================
        // INSERT (Create Student)
        // ===========================

        // Show the form to create a new student
        public IActionResult Create()
        {
            return View();
        }

        // Handle POST: Save new student to the database
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(user); // Add to database
                await _context.SaveChangesAsync(); // Save changes
                return RedirectToAction("Insert"); // Redirect to empty form again
            }

            return View(user); // Return with validation errors
        }

        // GET: FunController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FunController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FunController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FunController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
