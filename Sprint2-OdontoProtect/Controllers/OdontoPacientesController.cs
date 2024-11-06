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
    public class OdontoPacientesController : Controller
    {
        private readonly ModelContext _context;

        public OdontoPacientesController(ModelContext context)
        {
            _context = context;
        }

        // GET: OdontoPacientes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.OdontoPacientes.Include(o => o.Endereco);
            return View(await modelContext.ToListAsync());
        }

        // GET: OdontoPacientes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoPaciente = await _context.OdontoPacientes
                .Include(o => o.Endereco)
                    .ThenInclude(e => e.CidadeNavigation)
                    .ThenInclude(c => c.EstadoNavigation)
                    .ThenInclude(es => es.PaisNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (odontoPaciente == null)
            {
                return NotFound();
            }

            return View(odontoPaciente);
        }

        // GET: OdontoPacientes/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.OdontoEnderecos, "Id", "Id");
            return View();
        }

        // POST: OdontoPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cpf,DataNascimento,Email,Nome,Telefone,EnderecoId")] OdontoPaciente odontoPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odontoPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.OdontoEnderecos, "Id", "Id", odontoPaciente.EnderecoId);
            return View(odontoPaciente);
        }

        // GET: OdontoPacientes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoPaciente = await _context.OdontoPacientes.FindAsync(id);
            if (odontoPaciente == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.OdontoEnderecos, "Id", "Id", odontoPaciente.EnderecoId);
            return View(odontoPaciente);
        }

        // POST: OdontoPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Cpf,DataNascimento,Email,Nome,Telefone,EnderecoId")] OdontoPaciente odontoPaciente)
        {
            if (id != odontoPaciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontoPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontoPacienteExists(odontoPaciente.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.OdontoEnderecos, "Id", "Id", odontoPaciente.EnderecoId);
            return View(odontoPaciente);
        }

        // GET: OdontoPacientes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoPaciente = await _context.OdontoPacientes
                .Include(o => o.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoPaciente == null)
            {
                return NotFound();
            }

            return View(odontoPaciente);
        }

        // POST: OdontoPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var odontoPaciente = await _context.OdontoPacientes.FindAsync(id);
            if (odontoPaciente != null)
            {
                _context.OdontoPacientes.Remove(odontoPaciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontoPacienteExists(long id)
        {
            return _context.OdontoPacientes.Any(e => e.Id == id);
        }
    }
}
