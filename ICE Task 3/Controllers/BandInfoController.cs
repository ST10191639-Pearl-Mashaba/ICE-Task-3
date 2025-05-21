using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICE_Task_3.Data;
using ICE_Task_3.Models;

namespace ICE_Task_3.Controllers
{
    public class BandInfoController : Controller
    {
        private readonly BDBContext _context;

        public BandInfoController(BDBContext context)
        {
            _context = context;
        }

        // GET: BandInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.BandInfos.ToListAsync());
        }

        // GET: BandInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandInfo = await _context.BandInfos
                .FirstOrDefaultAsync(m => m.BandId == id);
            if (bandInfo == null)
            {
                return NotFound();
            }

            return View(bandInfo);
        }

        // GET: BandInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BandInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BandId,Name,MemberCount,DebutDate")] BandInfo bandInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bandInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bandInfo);
        }

        // GET: BandInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandInfo = await _context.BandInfos.FindAsync(id);
            if (bandInfo == null)
            {
                return NotFound();
            }
            return View(bandInfo);
        }

        // POST: BandInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BandId,Name,MemberCount,DebutDate")] BandInfo bandInfo)
        {
            if (id != bandInfo.BandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bandInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandInfoExists(bandInfo.BandId))
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
            return View(bandInfo);
        }

        // GET: BandInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bandInfo = await _context.BandInfos
                .FirstOrDefaultAsync(m => m.BandId == id);
            if (bandInfo == null)
            {
                return NotFound();
            }

            return View(bandInfo);
        }

        // POST: BandInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bandInfo = await _context.BandInfos.FindAsync(id);
            if (bandInfo != null)
            {
                _context.BandInfos.Remove(bandInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandInfoExists(int id)
        {
            return _context.BandInfos.Any(e => e.BandId == id);
        }
    }
}
