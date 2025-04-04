using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StInternships.Models;

namespace InternApp.Controllers
{
    public class InternshipController : Controller
    {

        private readonly ApplicationDbContext _context;
        public InternshipController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()

        {
            var internships = await _context.Internships
                .Include(i => i.Student)
                .Include(i => i.Company)
                .ToListAsync();

            return View(internships);
        }
        public IActionResult Create()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Company = _context.Company.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Internship internship)
        {
            if (ModelState.IsValid)
            {

                _context.Add(internship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Students = _context.Students.ToList();
            ViewBag.Company = _context.Company.ToList();
            return View(internship);

        }

        public async Task<IActionResult> LogHours(int id)
        {
            var internship = await _context.Internships.FindAsync(id);
            if (internship == null) return NotFound();

            return View(internship);
        }

        [HttpPost]

        public async Task<IActionResult> LogHours(int id, Internship model)
        {
            var internship = await _context.Internships.FindAsync(id);
            if (internship == null) return NotFound();

            internship.HoursLogged = model.HoursLogged;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }
        public async Task<IActionResult> Feedback(int id)
        {
            var internship = await _context.Internships.FindAsync(id);
            if (internship == null) return NotFound();

            return View(internship);
        }

        [HttpPost]

        public async Task<IActionResult> Feedback(int id, Internship model)
        {
            var internship = await _context.Internships.FindAsync(id);
            if (internship == null) return NotFound();

            internship.SupervisorFeedback = model.SupervisorFeedback;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }

    }

}