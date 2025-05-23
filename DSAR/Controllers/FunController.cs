using DSAR.Models;
<<<<<<< HEAD
using DSAR.ViewModels;
=======
>>>>>>> 56832847cdeabe744161f1af819174b8cf5fe246
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
<<<<<<< HEAD
                return RedirectToAction("Login","User");
=======
                return RedirectToAction("Login");
>>>>>>> 56832847cdeabe744161f1af819174b8cf5fe246
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == userId.Value);
            return View(user);
        }
<<<<<<< HEAD
        public async Task<IActionResult> list()
        {
            var users = await _context.User.ToListAsync();

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }
            var currentUser = await _context.User.FirstOrDefaultAsync(u => u.UserId == userId);

           

            var userView = new UserView
            {
                Users = users,
                FullName = currentUser.FullName,
                Email = currentUser.Email
            };

            return View(userView); // This passes both the list & current user
        }

        public async Task<IActionResult> Edit(int id)
        {
            var users = await _context.User.ToListAsync();

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> update(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Update(user); // ✅ Update user
                await _context.SaveChangesAsync(); // ✅ Save changes
                return RedirectToAction("list"); // Go back to list
            }

            return View(user); // In case of validation errors
        }

=======
        public async Task<ActionResult> list()
        {
            var students = await _context.User.ToListAsync(); // Fetch all students
            return View(); // Pass data to the view for printing
        }
>>>>>>> 56832847cdeabe744161f1af819174b8cf5fe246
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
<<<<<<< HEAD

        // DELETE (Remove Student)
        // ===========================

        // Show confirmation page for deleting a student
        public async Task<IActionResult> Delete(int? id)
        {
            var users = await _context.User.ToListAsync();

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int userid)
        {
            var user = await _context.User.FindAsync(userid);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("list"); // Redirect to user list after deletion
        }
=======
        public ActionResult Edit(int id)
        {
            return View();
        }

>>>>>>> 56832847cdeabe744161f1af819174b8cf5fe246
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
<<<<<<< HEAD
      
=======
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
>>>>>>> 56832847cdeabe744161f1af819174b8cf5fe246
    }
}
