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
    public class ResultsPagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultsPagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ResultsPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResultsPages.ToListAsync());
        }

        // GET: ResultsPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultsPage = await _context.ResultsPages.SingleOrDefaultAsync(m => m.Id == id);
            if (resultsPage == null)
            {
                return NotFound();
            }

            return View(resultsPage);
        }

        // GET: ResultsPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResultsPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Filename,Name")] ResultsPage resultsPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultsPage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(resultsPage);
        }

        // GET: ResultsPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultsPage = await _context.ResultsPages.SingleOrDefaultAsync(m => m.Id == id);
            if (resultsPage == null)
            {
                return NotFound();
            }
            return View(resultsPage);
        }

        // POST: ResultsPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Filename,Name")] ResultsPage resultsPage)
        {
            if (id != resultsPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultsPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultsPageExists(resultsPage.Id))
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
            return View(resultsPage);
        }

        // GET: ResultsPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultsPage = await _context.ResultsPages.SingleOrDefaultAsync(m => m.Id == id);
            if (resultsPage == null)
            {
                return NotFound();
            }

            return View(resultsPage);
        }

        // POST: ResultsPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultsPage = await _context.ResultsPages.SingleOrDefaultAsync(m => m.Id == id);
            _context.ResultsPages.Remove(resultsPage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ResultsPageExists(int id)
        {
            return _context.ResultsPages.Any(e => e.Id == id);
        }
    }
}
