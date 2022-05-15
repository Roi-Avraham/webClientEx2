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
using webClientEx2.Services;

namespace webClientEx2.Controllers
{
    public class Rates1Controller : Controller
    {
        private IRateService service;

        public Rates1Controller(IRateService _service)
        {
            service = _service;
        }

        // GET: Rates1
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAll());
        }

        public async Task<IActionResult> Search()
        {
            return View(await service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            return View(await service.Search(query));
        }

        // GET: Rates1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await service.Get(id));
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
            await service.Create(rate.Text, rate.Name, rate.RatingNum);
            return RedirectToAction("Search");
        }

        // GET: Rates1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await service.Get(id));
        }

        // POST: Rates1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Text,Name,Id,Date,RatingNum")] Rate rate)
        {

            await service.Edit(id, rate.Text, rate.Name, rate.RatingNum);

            return RedirectToAction(nameof(Search));

        }

        // GET: Rates1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await service.Get(id));
        }

        // POST: Rates1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.Delete(id);
            return RedirectToAction("Search");
        }
    }
}
