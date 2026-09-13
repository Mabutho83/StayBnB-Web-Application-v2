using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StayBnB_Web_Application_v2.Data;
using StayBnB_Web_Application_v2.Models;

namespace StayBnB_Web_Application_v2.Controllers
{
    public class HostPropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HostPropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HostProperties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HostProperties.Include(h => h.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HostProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostProperty = await _context.HostProperties
                .Include(h => h.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostProperty == null)
            {
                return NotFound();
            }

            return View(hostProperty);
        }

        // GET: HostProperties/Create
        public IActionResult Create()
        {
            ViewData["HostId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: HostProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,PricePerNight,HostId,Address")] HostProperty hostProperty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hostProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HostId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", hostProperty.HostId);
            return View(hostProperty);
        }

        // GET: HostProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostProperty = await _context.HostProperties.FindAsync(id);
            if (hostProperty == null)
            {
                return NotFound();
            }
            ViewData["HostId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", hostProperty.HostId);
            return View(hostProperty);
        }

        // POST: HostProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,PricePerNight,HostId,Address")] HostProperty hostProperty)
        {
            if (id != hostProperty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hostProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostPropertyExists(hostProperty.Id))
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
            ViewData["HostId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", hostProperty.HostId);
            return View(hostProperty);
        }

        // GET: HostProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostProperty = await _context.HostProperties
                .Include(h => h.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostProperty == null)
            {
                return NotFound();
            }

            return View(hostProperty);
        }

        // POST: HostProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hostProperty = await _context.HostProperties.FindAsync(id);
            if (hostProperty != null)
            {
                _context.HostProperties.Remove(hostProperty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostPropertyExists(int id)
        {
            return _context.HostProperties.Any(e => e.Id == id);
        }
    }
}
