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
    public class OdontoClinicasController : Controller
    {
        private readonly ModelContext _context;

        public OdontoClinicasController(ModelContext context)
        {
            _context = context;
        }

        // GET: OdontoClinicas
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.OdontoClinicas.Include(o => o.Endereco);
            return View(await modelContext.ToListAsync());
        }

        // GET: OdontoClinicas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoClinica = await _context.OdontoClinicas
                .Include(o => o.Endereco)
                    .ThenInclude(e => e.CidadeNavigation)
                    .ThenInclude(c => c.EstadoNavigation)
                    .ThenInclude(es => es.PaisNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (odontoClinica == null)
            {
                return NotFound();
            }

            return View(odontoClinica);
        }

        // GET: OdontoClinicas/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.OdontoEnderecos, "Id", "Id");
            return View();
        }

        // POST: OdontoClinicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cnpj,Descricao,EmailRepresentante,RazaoSocial,EnderecoId")] OdontoClinica odontoClinica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odontoClinica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.OdontoEnderecos, "Id", "Id", odontoClinica.EnderecoId);
            return View(odontoClinica);
        }

        // GET: OdontoClinicas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoClinica = await _context.OdontoClinicas.FindAsync(id);
            if (odontoClinica == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.OdontoEnderecos, "Id", "Id", odontoClinica.EnderecoId);
            return View(odontoClinica);
        }

        // POST: OdontoClinicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Cnpj,Descricao,EmailRepresentante,RazaoSocial,EnderecoId")] OdontoClinica odontoClinica)
        {
            if (id != odontoClinica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontoClinica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontoClinicaExists(odontoClinica.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.OdontoEnderecos, "Id", "Id", odontoClinica.EnderecoId);
            return View(odontoClinica);
        }

        // GET: OdontoClinicas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoClinica = await _context.OdontoClinicas
                .Include(o => o.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoClinica == null)
            {
                return NotFound();
            }

            return View(odontoClinica);
        }

        // POST: OdontoClinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var odontoClinica = await _context.OdontoClinicas.FindAsync(id);
            if (odontoClinica != null)
            {
                _context.OdontoClinicas.Remove(odontoClinica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontoClinicaExists(long id)
        {
            return _context.OdontoClinicas.Any(e => e.Id == id);
        }
    }
}
