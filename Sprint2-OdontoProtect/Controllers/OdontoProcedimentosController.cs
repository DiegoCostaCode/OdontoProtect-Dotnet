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
    public class OdontoProcedimentosController : Controller
    {
        private readonly ModelContext _context;

        public OdontoProcedimentosController(ModelContext context)
        {
            _context = context;
        }

        // GET: OdontoProcedimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.OdontoProcedimentos.ToListAsync());
        }

        // GET: OdontoProcedimentoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoProcedimento = await _context.OdontoProcedimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoProcedimento == null)
            {
                return NotFound();
            }

            return View(odontoProcedimento);
        }

        // GET: OdontoProcedimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OdontoProcedimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] OdontoProcedimento odontoProcedimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odontoProcedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odontoProcedimento);
        }

        // GET: OdontoProcedimentoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoProcedimento = await _context.OdontoProcedimentos.FindAsync(id);
            if (odontoProcedimento == null)
            {
                return NotFound();
            }
            return View(odontoProcedimento);
        }

        // POST: OdontoProcedimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Descricao")] OdontoProcedimento odontoProcedimento)
        {
            if (id != odontoProcedimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontoProcedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontoProcedimentoExists(odontoProcedimento.Id))
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
            return View(odontoProcedimento);
        }

        // GET: OdontoProcedimentoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoProcedimento = await _context.OdontoProcedimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoProcedimento == null)
            {
                return NotFound();
            }

            return View(odontoProcedimento);
        }

        // POST: OdontoProcedimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var odontoProcedimento = await _context.OdontoProcedimentos.FindAsync(id);
            if (odontoProcedimento != null)
            {
                _context.OdontoProcedimentos.Remove(odontoProcedimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontoProcedimentoExists(long id)
        {
            return _context.OdontoProcedimentos.Any(e => e.Id == id);
        }
    }
}
