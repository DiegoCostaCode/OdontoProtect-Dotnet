using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint2_OdontoProtect.Models;

namespace Sprint2_OdontoProtect.Controllers
{
    public class OdontoClinicaDoutoresController : Controller
    {
        private readonly ModelContext _context;

        public OdontoClinicaDoutoresController(ModelContext context)
        {
            _context = context;
        }

        // GET: OdontoClinicaDoutors
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.OdontoClinicaDoutors.Include(o => o.Clinica).Include(o => o.Doutor);
            return View(await modelContext.ToListAsync());
        }

        // GET: OdontoClinicaDoutors/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoClinicaDoutor = await _context.OdontoClinicaDoutors
                .Include(o => o.Clinica)
                .Include(o => o.Doutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoClinicaDoutor == null)
            {
                return NotFound();
            }

            return View(odontoClinicaDoutor);
        }

        // GET: OdontoClinicaDoutors/Create
        public IActionResult Create()
        {
            ViewData["ClinicaId"] = new SelectList(_context.OdontoClinicas, "Id", "Id");
            ViewData["DoutorId"] = new SelectList(_context.OdontoDoutors, "Id", "Id");
            return View();
        }

        // POST: OdontoClinicaDoutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataFimRelacionamento,DataRelacionamento,ClinicaId,DoutorId")] OdontoClinicaDoutor odontoClinicaDoutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odontoClinicaDoutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicaId"] = new SelectList(_context.OdontoClinicas, "Id", "Id", odontoClinicaDoutor.ClinicaId);
            ViewData["DoutorId"] = new SelectList(_context.OdontoDoutors, "Id", "Id", odontoClinicaDoutor.DoutorId);
            return View(odontoClinicaDoutor);
        }

        // GET: OdontoClinicaDoutors/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoClinicaDoutor = await _context.OdontoClinicaDoutors.FindAsync(id);
            if (odontoClinicaDoutor == null)
            {
                return NotFound();
            }
            ViewData["ClinicaId"] = new SelectList(_context.OdontoClinicas, "Id", "Id", odontoClinicaDoutor.ClinicaId);
            ViewData["DoutorId"] = new SelectList(_context.OdontoDoutors, "Id", "Id", odontoClinicaDoutor.DoutorId);
            return View(odontoClinicaDoutor);
        }

        // POST: OdontoClinicaDoutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DataFimRelacionamento,DataRelacionamento,ClinicaId,DoutorId")] OdontoClinicaDoutor odontoClinicaDoutor)
        {
            if (id != odontoClinicaDoutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontoClinicaDoutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontoClinicaDoutorExists(odontoClinicaDoutor.Id))
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
            ViewData["ClinicaId"] = new SelectList(_context.OdontoClinicas, "Id", "Id", odontoClinicaDoutor.ClinicaId);
            ViewData["DoutorId"] = new SelectList(_context.OdontoDoutors, "Id", "Id", odontoClinicaDoutor.DoutorId);
            return View(odontoClinicaDoutor);
        }

        // GET: OdontoClinicaDoutors/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoClinicaDoutor = await _context.OdontoClinicaDoutors
                .Include(o => o.Clinica)
                .Include(o => o.Doutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoClinicaDoutor == null)
            {
                return NotFound();
            }

            return View(odontoClinicaDoutor);
        }

        // POST: OdontoClinicaDoutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var odontoClinicaDoutor = await _context.OdontoClinicaDoutors.FindAsync(id);
            if (odontoClinicaDoutor != null)
            {
                _context.OdontoClinicaDoutors.Remove(odontoClinicaDoutor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontoClinicaDoutorExists(long id)
        {
            return _context.OdontoClinicaDoutors.Any(e => e.Id == id);
        }
    }
}
