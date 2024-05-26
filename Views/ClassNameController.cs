using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLOG.WEB.Data;
using BLOG.WEB.Models.Domain;

namespace BLOG.WEB.Views
{
    public class ClassNameController : Controller
    {
        private readonly BlogDbContext _context;

        public ClassNameController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: ClassName
        public async Task<IActionResult> Index()
        {
              return _context.ClassNames != null ? 
                          View(await _context.ClassNames.ToListAsync()) :
                          Problem("Entity set 'BlogDbContext.ClassName'  is null.");
        }

        // GET: ClassName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClassNames == null)
            {
                return NotFound();
            }

            var className = await _context.ClassNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (className == null)
            {
                return NotFound();
            }

            return View(className);
        }

        // GET: ClassName/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassName/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ClassName className)
        {
            if (ModelState.IsValid)
            {
                _context.Add(className);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(className);
        }

        // GET: ClassName/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClassNames == null)
            {
                return NotFound();
            }

            var className = await _context.ClassNames.FindAsync(id);
            if (className == null)
            {
                return NotFound();
            }
            return View(className);
        }

        // POST: ClassName/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ClassName className)
        {
            if (id != className.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(className);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassNameExists(className.Id))
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
            return View(className);
        }

        // GET: ClassName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClassNames == null)
            {
                return NotFound();
            }

            var className = await _context.ClassNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (className == null)
            {
                return NotFound();
            }

            return View(className);
        }

        // POST: ClassName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClassNames == null)
            {
                return Problem("Entity set 'BlogDbContext.ClassName'  is null.");
            }
            var className = await _context.ClassNames.FindAsync(id);
            if (className != null)
            {
                _context.ClassNames.Remove(className);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassNameExists(int id)
        {
          return (_context.ClassNames?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
