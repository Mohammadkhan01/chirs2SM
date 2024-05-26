using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLOG.WEB.Data;
using BLOG.WEB.Models.Domain;
using BLOG.WEB.ViewModel;

namespace BLOG.WEB.Controllers
{
    public class FeesHistoryController : Controller
    {
        private readonly BlogDbContext _context;

        public FeesHistoryController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: FeesHistory
        public async Task<IActionResult> Index()
        {
              return _context.FeesHistory != null ? 
                          View(await _context.FeesHistory.ToListAsync()) :
                          Problem("Entity set 'BlogDbContext.FeesHistory'  is null.");
        }

       
        // GET: FeesHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FeesHistory == null)
            {
                return NotFound();
            }

            var feesHistory = await _context.FeesHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feesHistory == null)
            {
                return NotFound();
            }

            return View(feesHistory);
        }


        // GET: Person/Create
        public IActionResult Create()
        {
            var students = _context.Person.ToList();
            
            var classname = _context.ClassNames.ToList();
            var viewModel = new FeesHistoryStudentView
            {
                FeesHistory = new FeesHistory(),
                Persons = students,
                
                ClassNames = classname
            };
            // var query = _context.ClassName.ToList();
            return View(viewModel);
        }



        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeesHistory person)
        {

            //Console.WriteLine(ViewBag.Session);

            if (person.Id > 0)
                _context.FeesHistory.Update(person);
            //   _context.Entry(person).State = System.Data.Entity.EntityState.Modified;
            else
            {
                _context.FeesHistory.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View("Create", person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FeesHistory == null)
            {
                return NotFound();
            }

            var person = await _context.FeesHistory.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View("Create", person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FeesHistory person)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FeesHistory == null)
            {
                return NotFound();
            }

            var person = await _context.FeesHistory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FeesHistory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person'  is null.");
            }
            var person = await _context.FeesHistory.FindAsync(id);
            if (person != null)
            {
                _context.FeesHistory.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return (_context.FeesHistory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}



