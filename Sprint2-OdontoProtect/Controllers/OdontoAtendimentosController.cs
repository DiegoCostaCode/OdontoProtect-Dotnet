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
    public class OdontoAtendimentosController : Controller
    {
        private readonly ModelContext _context;

        public OdontoAtendimentosController(ModelContext context)
        {
            _context = context;
        }

        // GET: OdontoAtendimentoes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.OdontoAtendimentos.Include(o => o.Clinica).Include(o => o.Paciente).Include(o => o.Procedimento);
            return View(await modelContext.ToListAsync());
        }

        // GET: OdontoAtendimentoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoAtendimento = await _context.OdontoAtendimentos
                .Include(o => o.Clinica)
                .Include(o => o.Paciente)
                .Include(o => o.Procedimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoAtendimento == null)
            {
                return NotFound();
            }

            return View(odontoAtendimento);
        }

        // GET: OdontoAtendimentoes/Create
        public IActionResult Create()
        {
            ViewData["ClinicaId"] = new SelectList(_context.OdontoClinicas, "Id", "Id");
            ViewData["PacienteId"] = new SelectList(_context.OdontoPacientes, "Id", "Id");
            ViewData["ProcedimentoId"] = new SelectList(_context.OdontoProcedimentos, "Id", "Id");
            return View();
        }

        // POST: OdontoAtendimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Custo,DataHoraAtendimento,Descrição,ClinicaId,PacienteId,ProcedimentoId")] OdontoAtendimento odontoAtendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odontoAtendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClinicaId"] = new SelectList(_context.OdontoClinicas, "Id", "Id", odontoAtendimento.ClinicaId);
            ViewData["PacienteId"] = new SelectList(_context.OdontoPacientes, "Id", "Id", odontoAtendimento.PacienteId);
            ViewData["ProcedimentoId"] = new SelectList(_context.OdontoProcedimentos, "Id", "Id", odontoAtendimento.ProcedimentoId);
            return View(odontoAtendimento);
        }

        // GET: OdontoAtendimentoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoAtendimento = await _context.OdontoAtendimentos.FindAsync(id);
            if (odontoAtendimento == null)
            {
                return NotFound();
            }
            ViewData["ClinicaId"] = new SelectList(_context.OdontoClinicas, "Id", "Id", odontoAtendimento.ClinicaId);
            ViewData["PacienteId"] = new SelectList(_context.OdontoPacientes, "Id", "Id", odontoAtendimento.PacienteId);
            ViewData["ProcedimentoId"] = new SelectList(_context.OdontoProcedimentos, "Id", "Id", odontoAtendimento.ProcedimentoId);
            return View(odontoAtendimento);
        }

        // POST: OdontoAtendimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Custo,DataHoraAtendimento,Descrição,ClinicaId,PacienteId,ProcedimentoId")] OdontoAtendimento odontoAtendimento)
        {
            if (id != odontoAtendimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odontoAtendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdontoAtendimentoExists(odontoAtendimento.Id))
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
            ViewData["ClinicaId"] = new SelectList(_context.OdontoClinicas, "Id", "Id", odontoAtendimento.ClinicaId);
            ViewData["PacienteId"] = new SelectList(_context.OdontoPacientes, "Id", "Id", odontoAtendimento.PacienteId);
            ViewData["ProcedimentoId"] = new SelectList(_context.OdontoProcedimentos, "Id", "Id", odontoAtendimento.ProcedimentoId);
            return View(odontoAtendimento);
        }

        // GET: OdontoAtendimentoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odontoAtendimento = await _context.OdontoAtendimentos
                .Include(o => o.Clinica)
                .Include(o => o.Paciente)
                .Include(o => o.Procedimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (odontoAtendimento == null)
            {
                return NotFound();
            }

            return View(odontoAtendimento);
        }

        // POST: OdontoAtendimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var odontoAtendimento = await _context.OdontoAtendimentos.FindAsync(id);
            if (odontoAtendimento != null)
            {
                _context.OdontoAtendimentos.Remove(odontoAtendimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdontoAtendimentoExists(long id)
        {
            return _context.OdontoAtendimentos.Any(e => e.Id == id);
        }
    }
}
