using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLOG.WEB.Data;
using BLOG.WEB.Models.Domain;
using BLOG.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BLOG.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly BlogDbContext _context;

       

        public AccountController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            return _context.Users != null ?
                       View(await _context.Users.ToListAsync()) :
                      Problem("Entity set 'ApplicationDbContext.Person'  is null.");
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            // var query = _context.ClassName.ToList();
            return View(new User { Id = 0 });
        }



        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id > 0)
                    _context.Users.Update(user);
                //   _context.Entry(person).State = System.Data.Entity.EntityState.Modified;
                else
                    if(_context.Users.Where(u=>u.Email == user.Email || user.UserName == user.UserName).Any())
                    {
                        ModelState.AddModelError("Email", "UserName or Email alreday exists");
                        return View("Account", user);
                    }
                    _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View("Create", user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);
            var loginUser = _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password && u.IsActive == true).FirstOrDefault();
            if(loginUser == null)
            {
                ModelState.AddModelError("UserName", "User Name or Password is incorrect, please try with correct user name and password");
                return View("Login", user);
            }
            else
            {
                //Session - i will add this
                 HttpContext.Session.SetString("Username", loginUser.UserName);
                //ViewBag.Session = loginUser.UserName;
                //HttpContext.Session["UserName"] = loginUser.UserName;
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("Create", user);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(user.Id))
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
            return View(user);
        }

       

       

        private bool PersonExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}