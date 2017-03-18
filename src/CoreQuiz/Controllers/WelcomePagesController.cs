using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreQuiz.Data;
using CoreQuiz.Models;

namespace CoreQuiz.Controllers
{
    public class WelcomePagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WelcomePagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WelcomePages
        public async Task<IActionResult> Index()
        {
            return View(await _context.WelcomePages.ToListAsync());
        }

        // GET: WelcomePages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomePage = await _context.WelcomePages.SingleOrDefaultAsync(m => m.Id == id);
            if (welcomePage == null)
            {
                return NotFound();
            }

            return View(welcomePage);
        }

        // GET: WelcomePages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WelcomePages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Filename,Name")] WelcomePage welcomePage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(welcomePage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(welcomePage);
        }

        // GET: WelcomePages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomePage = await _context.WelcomePages.SingleOrDefaultAsync(m => m.Id == id);
            if (welcomePage == null)
            {
                return NotFound();
            }
            return View(welcomePage);
        }

        // POST: WelcomePages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Filename,Name")] WelcomePage welcomePage)
        {
            if (id != welcomePage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(welcomePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WelcomePageExists(welcomePage.Id))
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
            return View(welcomePage);
        }

        // GET: WelcomePages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomePage = await _context.WelcomePages.SingleOrDefaultAsync(m => m.Id == id);
            if (welcomePage == null)
            {
                return NotFound();
            }

            return View(welcomePage);
        }

        // POST: WelcomePages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var welcomePage = await _context.WelcomePages.SingleOrDefaultAsync(m => m.Id == id);
            _context.WelcomePages.Remove(welcomePage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WelcomePageExists(int id)
        {
            return _context.WelcomePages.Any(e => e.Id == id);
        }
    }
}
