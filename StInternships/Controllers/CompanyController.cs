using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StInternships.Models;

namespace StInternships.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()

        {
            var Company = await _context.Company.ToListAsync();

            return View(Company);
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {

                _context.Add(company);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }


            return View(company);
        }

        public async Task<IActionResult> Details(int? id)
        {

            var company = await _context.Company.FirstOrDefaultAsync(m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var company = await _context.Company.FirstOrDefaultAsync(m => m.Id == id);


            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            return View(company);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }


        }
}
