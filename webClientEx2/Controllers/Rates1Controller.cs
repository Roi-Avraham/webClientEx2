#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webClientEx2.Data;
using webClientEx2.Models;

namespace webClientEx2.Controllers
{
    public class Rates1Controller : Controller
    {
        private readonly webClientEx2Context _context;

        public Rates1Controller(webClientEx2Context context)
        {
            _context = context;
        }

        // GET: Rates1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rate.ToListAsync());
        }

        public async Task<IActionResult> Search()
        {
            return View(await _context.Rate.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            var q = from   rate in _context.Rate
                    where  rate.Text.Contains(query) || rate.Name.Contains(query)    
                    select rate;
            return View(await q.ToListAsync());
        }

        // GET: Rates1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // GET: Rates1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rates1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Text,Name,Id,Date,RatingNum")] Rate rate)
        {
            rate.Date = DateTime.Now;   
            if (ModelState.IsValid)
            {
                _context.Add(rate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Search));
            }
            return View(rate);
        }

        // GET: Rates1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }
            return View(rate);
        }

        // POST: Rates1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Text,Name,Id,Date,RatingNum")] Rate rate)
        {
            rate.Date = DateTime.Now;
            if (id != rate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RateExists(rate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Search));
            }
            return View(rate);
        }

        // GET: Rates1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rate = await _context.Rate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rate == null)
            {
                return NotFound();
            }

            return View(rate);
        }

        // POST: Rates1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rate = await _context.Rate.FindAsync(id);
            _context.Rate.Remove(rate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Search));
        }

        private bool RateExists(int id)
        {
            return _context.Rate.Any(e => e.Id == id);
        }
    }
}
