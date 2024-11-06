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
    public class OdontoEnderecoesController : Controller
    {
        private readonly ModelContext _context;

        public OdontoEnderecoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: OdontoEnderecoes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.OdontoEnderecos.Include(o => o.CidadeNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: OdontoEnderecoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoEndereco = await _context.OdontoEnderecos
                .Include(o => o.CidadeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoEndereco == null)
            {
                return NotFound();
            }

            return View(odontoEndereco);
        }

        // GET: OdontoEnderecoes/Create
        public IActionResult Create()
        {
            ViewData["Cidade"] = new SelectList(_context.OdontoCidades, "Id", "Id");
            return View();
        }

        // POST: OdontoEnderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cep,Complemento,Numero,Rua,Cidade")] OdontoEndereco odontoEndereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odontoEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cidade"] = new SelectList(_context.OdontoCidades, "Id", "Id", odontoEndereco.Cidade);
            return View(odontoEndereco);
        }

        // GET: OdontoEnderecoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoEndereco = await _context.OdontoEnderecos.FindAsync(id);
            if (odontoEndereco == null)
            {
                return NotFound();
            }
            ViewData["Cidade"] = new SelectList(_context.OdontoCidades, "Id", "Id", odontoEndereco.Cidade);
            return View(odontoEndereco);
        }

        // POST: OdontoEnderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Cep,Complemento,Numero,Rua,Cidade")] OdontoEndereco odontoEndereco)
        {
            if (id != odontoEndereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontoEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontoEnderecoExists(odontoEndereco.Id))
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
            ViewData["Cidade"] = new SelectList(_context.OdontoCidades, "Id", "Id", odontoEndereco.Cidade);
            return View(odontoEndereco);
        }

        // GET: OdontoEnderecoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoEndereco = await _context.OdontoEnderecos
                .Include(o => o.CidadeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoEndereco == null)
            {
                return NotFound();
            }

            return View(odontoEndereco);
        }

        // POST: OdontoEnderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var odontoEndereco = await _context.OdontoEnderecos.FindAsync(id);
            if (odontoEndereco != null)
            {
                _context.OdontoEnderecos.Remove(odontoEndereco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontoEnderecoExists(long id)
        {
            return _context.OdontoEnderecos.Any(e => e.Id == id);
        }
    }
}
