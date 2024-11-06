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
    public class OdontoDoutoresController : Controller
    {
        private readonly ModelContext _context;

        public OdontoDoutoresController(ModelContext context)
        {
            _context = context;
        }

        // GET: OdontoDoutors
        public async Task<IActionResult> Index()
        {
            return View(await _context.OdontoDoutors.ToListAsync());
        }

        // GET: OdontoDoutors/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoDoutor = await _context.OdontoDoutors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoDoutor == null)
            {
                return NotFound();
            }

            return View(odontoDoutor);
        }

        // GET: OdontoDoutors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OdontoDoutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cpf,Crm,Nome")] OdontoDoutor odontoDoutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odontoDoutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odontoDoutor);
        }

        // GET: OdontoDoutors/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoDoutor = await _context.OdontoDoutors.FindAsync(id);
            if (odontoDoutor == null)
            {
                return NotFound();
            }
            return View(odontoDoutor);
        }

        // POST: OdontoDoutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Cpf,Crm,Nome")] OdontoDoutor odontoDoutor)
        {
            if (id != odontoDoutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontoDoutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontoDoutorExists(odontoDoutor.Id))
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
            return View(odontoDoutor);
        }

        // GET: OdontoDoutors/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoDoutor = await _context.OdontoDoutors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoDoutor == null)
            {
                return NotFound();
            }

            return View(odontoDoutor);
        }

        // POST: OdontoDoutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var odontoDoutor = await _context.OdontoDoutors.FindAsync(id);
            if (odontoDoutor != null)
            {
                _context.OdontoDoutors.Remove(odontoDoutor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontoDoutorExists(long id)
        {
            return _context.OdontoDoutors.Any(e => e.Id == id);
        }
    }
}
