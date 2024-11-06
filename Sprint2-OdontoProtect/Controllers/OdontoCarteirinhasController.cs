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
    public class OdontoCarteirinhasController : Controller
    {
        private readonly ModelContext _context;

        public OdontoCarteirinhasController(ModelContext context)
        {
            _context = context;
        }

        // GET: OdontoCarteirinhas
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.OdontoCarteirinhas.Include(o => o.Paciente).Include(o => o.Plano);
            return View(await modelContext.ToListAsync());
        }

        // GET: OdontoCarteirinhas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoCarteirinha = await _context.OdontoCarteirinhas
                .Include(o => o.Paciente)
                .Include(o => o.Plano)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoCarteirinha == null)
            {
                return NotFound();
            }

            return View(odontoCarteirinha);
        }

        // GET: OdontoCarteirinhas/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.OdontoPacientes, "Id", "Id");
            ViewData["PlanoId"] = new SelectList(_context.OdontoPlanos, "Id", "Id");
            return View();
        }

        // POST: OdontoCarteirinhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emissao,Numero,Validade,PacienteId,PlanoId")] OdontoCarteirinha odontoCarteirinha)
        {
            if (ModelState.IsValid)
            {
                odontoCarteirinha.Id = Guid.NewGuid();
                _context.Add(odontoCarteirinha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.OdontoPacientes, "Id", "Id", odontoCarteirinha.PacienteId);
            ViewData["PlanoId"] = new SelectList(_context.OdontoPlanos, "Id", "Id", odontoCarteirinha.PlanoId);
            return View(odontoCarteirinha);
        }

        // GET: OdontoCarteirinhas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoCarteirinha = await _context.OdontoCarteirinhas.FindAsync(id);
            if (odontoCarteirinha == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.OdontoPacientes, "Id", "Id", odontoCarteirinha.PacienteId);
            ViewData["PlanoId"] = new SelectList(_context.OdontoPlanos, "Id", "Id", odontoCarteirinha.PlanoId);
            return View(odontoCarteirinha);
        }

        // POST: OdontoCarteirinhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Emissao,Numero,Validade,PacienteId,PlanoId")] OdontoCarteirinha odontoCarteirinha)
        {
            if (id != odontoCarteirinha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontoCarteirinha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontoCarteirinhaExists(odontoCarteirinha.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.OdontoPacientes, "Id", "Id", odontoCarteirinha.PacienteId);
            ViewData["PlanoId"] = new SelectList(_context.OdontoPlanos, "Id", "Id", odontoCarteirinha.PlanoId);
            return View(odontoCarteirinha);
        }

        // GET: OdontoCarteirinhas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoCarteirinha = await _context.OdontoCarteirinhas
                .Include(o => o.Paciente)
                .Include(o => o.Plano)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoCarteirinha == null)
            {
                return NotFound();
            }

            return View(odontoCarteirinha);
        }

        // POST: OdontoCarteirinhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var odontoCarteirinha = await _context.OdontoCarteirinhas.FindAsync(id);
            if (odontoCarteirinha != null)
            {
                _context.OdontoCarteirinhas.Remove(odontoCarteirinha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontoCarteirinhaExists(Guid id)
        {
            return _context.OdontoCarteirinhas.Any(e => e.Id == id);
        }
    }
}
